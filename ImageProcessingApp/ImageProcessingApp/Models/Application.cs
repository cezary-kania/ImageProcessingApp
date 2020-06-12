using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageProcessingApp.Models
{
    public class Application
    {
        public Dictionary<string, Image> images  { get; private set;}
        public Application()
        {
            images = new Dictionary<string, Image>();
        }
        public bool AddNewImage(ref string filename)
        {
            Bitmap bmp = new Bitmap(System.Drawing.Image.FromFile(filename));
            string tmpfileName = RenderNewTmpName(ref filename);
            images.Add(tmpfileName, new Image(bmp, tmpfileName));
            return new List<string>(images.Keys).Contains(tmpfileName);
        }
        public string RenderNewTmpName(ref string orginalName)
        {
            StringBuilder tmpfilename = new StringBuilder(orginalName);
            List<string> imgNames = new List<string>(images.Keys);
            int indexOfExt = orginalName.LastIndexOf('.');
            string fName = orginalName.Substring(0, indexOfExt),
                   fExtention = orginalName.Substring(indexOfExt + 1);
            for (int i = 1; imgNames.Contains(tmpfilename.ToString()); ++i) {
                tmpfilename.Clear();
                tmpfilename.Append($"{fName}({i}).{fExtention}");
            }
            orginalName = tmpfilename.ToString();
            return tmpfilename.ToString();
        }
        public string RenderNewTmpName()
        {
            string filename = "Untitled.bmp";
            return RenderNewTmpName(ref filename);
        }
        public void CloseAllImages()
        {
            foreach (string image in images.Keys) images.Remove(image);
        }
        public Image GetImage(string filename)
        {
            return images[filename];
        }
        public void RemoveImage(string filename)
        {
            images.Remove(filename);
        }
    }
}
