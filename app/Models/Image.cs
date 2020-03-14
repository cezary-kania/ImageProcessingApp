﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace APO_v1.Models
{
    public class Image
    {
        public uint[][] LUT { get; set; }
        public enum EColorFormat
        {
            GrayScale,
            RGB
        }
        public EColorFormat ColorFormat { get; private set; }
        public string OrginalFileName { get; private set; }
        public string TmpfileName { get; private set; }
        public BitmapImage bitmapImg { get; private set; }
        public int Width { get { return bitmapImg.PixelWidth; } }
        public int Height { get { return bitmapImg.PixelHeight; } }
        public Image(string orginalFileName, string tmpfileName)
        {
            this.OrginalFileName = orginalFileName;
            this.TmpfileName = tmpfileName;
            bitmapImg = PrepareBMPIMG(orginalFileName);
            ColorFormat = CheckImgColorFormat(bitmapImg);
            FindLUT(bitmapImg);
        }
        private BitmapImage PrepareBMPIMG(string orginalFileName)
        {
            BitmapImage bitmapImg = new BitmapImage();
            bitmapImg.BeginInit();
            bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImg.UriSource = new Uri(orginalFileName);
            bitmapImg.EndInit();
            return bitmapImg;
        }
        private void FindLUT(BitmapImage bitmap)
        {
            if (ColorFormat == EColorFormat.GrayScale) LUT = new uint[1][];
            else LUT = new uint[3][];
            for (int i = 0; i < LUT.Length; i++)
                LUT[i] = CountLUT(i, bitmap);
        }
        private EColorFormat CheckImgColorFormat(BitmapImage bitmap)
        {
            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmap.CopyPixels(pixels, stride, 0);

            for (int x = 0; x < bitmap.PixelWidth; ++x)
            {
                for (int y = 0; y < bitmap.PixelHeight; y++)
                {
                    int index = y * stride + 4 * x;
                    if (!(pixels[index] == pixels[index + 1] && pixels[index] == pixels[index + 2])) return EColorFormat.RGB;
                }
            }
            return EColorFormat.GrayScale;
        }
        private uint[] CountLUT(int colorIndex, BitmapImage bitmap)
        {
            uint[] singleLUT = new uint[256];
            for (int i = 0; i < 256; i++)
                singleLUT[i] = 0;

            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmap.CopyPixels(pixels, stride, 0);

            for (int x = 0; x < bitmap.PixelWidth; ++x)
            {
                for (int y = 0; y < bitmap.PixelHeight; y++)
                {
                    int indexN = y * stride + 4 * x;
                    ++singleLUT[pixels[indexN + colorIndex]];
                }
            }

            return singleLUT;
        }
        public BitmapImage ReloadBitmap()
        {
            byte[] pixels = Utils.GetPixels(bitmapImg);
            int stride = Width * 4;
            int size = Height * stride;
            Bitmap bmp = Utils.BitmapImage2Bitmap(bitmapImg);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int index = j * stride + 4 * i;
                    Color color = Color.FromArgb((int)LUT[0][pixels[index]], (int)LUT[1][pixels[index + 1]], (int)LUT[2][pixels[index + 2]]);
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            return bitmapImg;
        }
        public void RGBStretching()
        {
           
            Bitmap bmp = Utils.BitmapImage2Bitmap(bitmapImg);
            for (int k = 0; k < LUT.Length; k++)
            {
                uint Lmin = 0, Lmax = (uint)LUT[k].Length - 1, max, min;
                max = Lmax; min = Lmin;
                for (uint i = 0; i < LUT[k].Length; i++)
                {
                    if (min == Lmin && LUT[k][i] > 0) min = i + 1;
                    if (max == Lmax && LUT[k][Lmax - i] > 0) max = Lmax - i - 1;
                }
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        byte[] colors = new byte[] {
                            bmp.GetPixel(x,y).R,
                            bmp.GetPixel(x,y).G,
                            bmp.GetPixel(x,y).B,
                        };
                        colors[k] = CountNewColorValue(colors[k], Lmin, Lmax, min, max);
                        bmp.SetPixel(x, y, Color.FromArgb(colors[0], colors[1], colors[2]));
                    }
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            FindLUT(bitmapImg);
        }
        private void GrayScaleStretching()
        {
            Bitmap bmp = Utils.BitmapImage2Bitmap(bitmapImg);
            for (int k = 0; k < LUT.Length; k++)
            {
                uint Lmin = 0, Lmax = (uint)LUT[k].Length - 1, max, min;
                max = Lmax; min = Lmin;
                for (uint i = 0; i < LUT[k].Length; i++)
                {
                    if (min == Lmin && LUT[k][i] > 0) min = i + 1;
                    if (max == Lmax && LUT[k][Lmax - i] > 0) max = Lmax - i - 1;
                }
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                       
                        byte color = bmp.GetPixel(x, y).R;
                        color = CountNewColorValue(color, Lmin, Lmax, min, max);
                        bmp.SetPixel(x, y, Color.FromArgb(color, color, color));
                    }
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            FindLUT(bitmapImg);
        }
        public void HistStretching()
        {
            if (ColorFormat.Equals(EColorFormat.GrayScale)) GrayScaleStretching();
            else if (ColorFormat.Equals(EColorFormat.RGB)) RGBStretching();
        }
        private byte CountNewColorValue(int color, uint Lmin, uint Lmax, uint min, uint max)
        {
            if (color < min) return Convert.ToByte(Lmin);
            if (color > max) return Convert.ToByte(Lmax);
            return Convert.ToByte((color - min) * Lmax / (max - min));
        }
    }
}