using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
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
        public static string SaveBmpTmp(Bitmap bmp)
        {
            string fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".bmp";
            FileStream stream = File.Create(fileName);
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            stream.Close();
            return fileName;
        }
        public static byte[,,] BmpToArray(Bitmap bmp)
        {
            byte[,,] imgArray = new byte[bmp.Height, bmp.Width, 3];
            for (int y = 0; y < bmp.Height; ++y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    Color color = bmp.GetPixel(x, y);
                    imgArray[y, x, 0] = color.R;
                    imgArray[y, x, 1] = color.G;
                    imgArray[y, x, 2] = color.B;
                }
            }
            return imgArray;
        }
        public static Bitmap EmguImgToBmp(byte[,,] imgArray)
        {
            int width = imgArray.GetLength(1);
            int height = imgArray.GetLength(0);
            Bitmap bmp = new Bitmap(width,height);
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    int red = imgArray[y, x, 0];
                    int green = imgArray[y, x, 1];
                    int blue = imgArray[y, x, 2];
                    Color color = Color.FromArgb(blue, green, red);
                    bmp.SetPixel(x, y, color);
                }
            }
            return bmp;
        }
        public static Bitmap EmguImgToGrayBmp(byte[,,] imgArray)
        {
            int width = imgArray.GetLength(1);
            int height = imgArray.GetLength(0);
            Bitmap bmp = new Bitmap(width, height);
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    int gray = imgArray[y, x, 0];
                    Color color = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(x, y, color);
                }
            }
            return bmp;
        }
        public static byte[,,] BmpToGraySArray(Bitmap bmp)
        {
            byte[,,] imgArray = new byte[bmp.Height, bmp.Width, 1];
            for (int y = 0; y < bmp.Height; ++y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    Color color = bmp.GetPixel(x, y);
                    imgArray[y, x, 0] = (byte) ((color.R + color.G + color.B) / 3);
                }
            }
            return imgArray;
        }
        public static int[,,] ByteArrToIntArr(byte[,,] byteArr)
        {
            int width = byteArr.GetLength(0);
            int height = byteArr.GetLength(1);
            int thrdDim = byteArr.GetLength(2);
            int[,,] intArr = new int[width, height, thrdDim];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < thrdDim; z++)
                    {
                        intArr[x, y, z] = (int)byteArr[x, y, z];
                    }
                }
            }
            return intArr;
        }
        public static Bitmap BmpFromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = (Bitmap) Image.FromStream(ms);
            return img;
        }
    }
}
