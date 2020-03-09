using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
namespace APO_v1
{
    static class Utils
    {
        public static void SaveFileAs(BitmapImage img, string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bmp file (*.bmp)|*.bmp";
            Bitmap bmp = BitmapImage2Bitmap(img);
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream stream =
                new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }
        public static void SaveFileAs(Bitmap bmp, string filename)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bmp file (*.bmp)|*.bmp";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream stream =
                new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }
        public static void SaveFile(BitmapImage img, string filename)
        {
            Bitmap bmp = BitmapImage2Bitmap(img);
            using (FileStream stream =
                new FileStream(filename, FileMode.Open))
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                }
        }
        public static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
    }
}
