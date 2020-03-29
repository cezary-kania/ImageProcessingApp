using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
namespace ImageProcessingApp
{
    public class Utils
    {
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
        public static void SaveFile(BitmapImage img, string filename)
        {
            Bitmap bmp = BitmapImage2Bitmap(img);
            using (FileStream stream =
                new FileStream(filename, FileMode.Open))
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
        public static void SaveFile(Bitmap img, string filename)
        {
            using (FileStream stream =
                new FileStream(filename, FileMode.Open))
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
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
        public static byte[] GetPixels(BitmapImage bitmap)
        {
            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmap.CopyPixels(pixels, stride, 0);
            return pixels;
        }
    }
}
