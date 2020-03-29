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
            string tmpfileName = orginalName;
            List<string> keys = new List<string>(images.Keys);
            for (int i = 1; keys.Contains(tmpfileName); ++i)
                tmpfileName = string.Format("{0}({1}).{2} ", orginalName.Split('.')[0], i, orginalName.Split('.')[1]);
            orginalName = tmpfileName;
            return tmpfileName;
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
