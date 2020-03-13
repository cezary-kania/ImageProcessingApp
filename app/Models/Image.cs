using System;
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
    }
}
