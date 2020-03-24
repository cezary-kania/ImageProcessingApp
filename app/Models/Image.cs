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
        private uint[][] ColorRedirect;
        private int colorsNum;
        public BitmapImage imgCopy;
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
            ResetColorRedirection();
        }
        private void ResetColorRedirection()
        {
            if (ColorFormat.Equals(EColorFormat.GrayScale))
                ColorRedirect = new uint[][] { new uint[256] };
            else
                ColorRedirect = new uint[][] { new uint[256], new uint[256], new uint[256], };
            for (int i = 0; i < colorsNum; i++)
                for (int j = 0; j < ColorRedirect[i].Length; j++)
                    ColorRedirect[i][j] = (uint)j;
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
        public void FindLUT()
        {
            FindLUT(bitmapImg);
        }
        private void FindLUT(BitmapImage bitmap)
        {
            if (ColorFormat == EColorFormat.GrayScale)
            {
                colorsNum = 1;
                LUT = new uint[1][];
            }

            else {
                LUT = new uint[4][];
                colorsNum = 3;
            }
            
            for (int i = 0; i < LUT.Length; i++)
                LUT[i] = CountLUT(i, bitmap);

            if(ColorFormat == EColorFormat.RGB)
            {
                LUT[3] = new uint[LUT[0].Length];
                ReloadCulumatedHistIfExists();
            }
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
                    Color color;
                    if(ColorFormat.Equals(EColorFormat.RGB))
                        color = Color.FromArgb((int)ColorRedirect[0][pixels[index]], (int)ColorRedirect[1][pixels[index + 1]], (int)ColorRedirect[2][pixels[index + 2]]);
                    else color = Color.FromArgb((int)ColorRedirect[0][pixels[index]], (int)ColorRedirect[0][pixels[index + 1]], (int)ColorRedirect[0][pixels[index + 2]]);
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            return bitmapImg;
        }
        public void RGBStretching()
        {
           
            Bitmap bmp = Utils.BitmapImage2Bitmap(bitmapImg);
            for (int k = 0; k < colorsNum; k++)
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
            for (int k = 0; k < colorsNum; k++)
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
        //*/
        public void HistStretching()
        {
            for (int i = 0; i < colorsNum; i++)
            {
                LUT[i] = HistogramOperations.LUTStretching(LUT[i]).Item1;
                ColorRedirect[i] = HistogramOperations.LUTStretching(LUT[i]).Item2;
            }
            ReloadCulumatedHistIfExists();
            ReloadBitmap();
            ResetColorRedirection();
        }
        public void LumRangeStretching(uint p1, uint p2)
        {
            /*for (int i = 0; i < colorsNum; i++)
            {
                uint Lmin = 0, Lmax = (uint)LUT[i].Length - 1,
                     max = p2, min = p1;
                for (uint j = 0; j < LUT[i].Length; j++)
                {
                    if (min == p1 && LUT[i][j] > 0) min = j;
                    if (max == p2 && LUT[i][p2 - j] > 0) max = p2 - j;
                }
                for (uint j = 0; j < LUT[i].Length; j++)
                {
                    if (j < min)
                        ColorRedirect[i][j] = p1;
                    else if (j > max)
                        ColorRedirect[i][j] = p2;
                    else
                        ColorRedirect[i][j] = (j - min) * p2 / max - min;
                }
            }
            */

            Bitmap bmp = Utils.BitmapImage2Bitmap(bitmapImg);
            for (int k = 0; k < colorsNum; k++)
            {
                uint Lmin = 0, Lmax = (uint)LUT[k].Length - 1, max, min;
                max = p2; min = p1;
                for (uint i = 0; i < LUT[k].Length; i++)
                {
                    if (min == p1 && LUT[k][i] > 0) min = i + 1;
                    if (max == p2 && LUT[k][p2 - i] > 0) max = p2 - i - 1;
                }
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {

                        byte color = bmp.GetPixel(x, y).R;
                        color = CountNewColorValue(color, p1, p2, min, max);
                        bmp.SetPixel(x, y, Color.FromArgb(color, color, color));
                    }
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            FindLUT(bitmapImg);

            ReloadBitmap();
            ResetColorRedirection();
        }
        public void HistAligment()
        {
            for (int i = 0; i < colorsNum; i++)
            {
                LUT[i] = HistogramOperations.LUTAlignment(LUT[i]).Item1;
                ColorRedirect[i] = HistogramOperations.LUTAlignment(LUT[i]).Item2;
            }
            ReloadCulumatedHistIfExists();
            ReloadBitmap();
            ResetColorRedirection();
        }
        private void ReloadCulumatedHistIfExists()
        {
            if(colorsNum == 3)
                for (int i = 0; i < LUT[3].Length; i++)
                    LUT[3][i] = LUT[0][i] + LUT[1][i] + LUT[2][i];
        }
        /*/
        public void HistStretching()
        {
            if (ColorFormat.Equals(EColorFormat.GrayScale)) GrayScaleStretching();
            else if (ColorFormat.Equals(EColorFormat.RGB)) RGBStretching();
        }
        //*/
        private byte CountNewColorValue(int color, uint Lmin, uint Lmax, uint min, uint max)
        {
            if (color < min) return Convert.ToByte(Lmin);
            if (color > max) return Convert.ToByte(Lmax);
            return Convert.ToByte((color - min) * Lmax / (max - min));
        }
        public void ImageNegation()
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
                    Color oldColor = bmp.GetPixel(i, j), color;
                    if (ColorFormat.Equals(EColorFormat.GrayScale))
                        color = Color.FromArgb(oldColor.A,LUT[0].Length - 1 - pixels[index], LUT[0].Length - 1 - pixels[index], LUT[0].Length - 1 - pixels[index]);
                    else
                        color = Color.FromArgb(oldColor.A, LUT[0].Length - 1 - pixels[index], LUT[1].Length - 1 - pixels[index + 1], LUT[2].Length - 1 - pixels[index + 2]);
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            FindLUT(bitmapImg);
            ReloadCulumatedHistIfExists();
            ReloadBitmap();
        }
        public void OnePBinaryThresholing(int p1)
        {
            if (imgCopy == null)
                imgCopy = bitmapImg.Clone();
            byte[] pixels = Utils.GetPixels(imgCopy.Clone());
            int stride = Width * 4;
            int size = Height * stride;
            Bitmap bmp = Utils.BitmapImage2Bitmap(imgCopy.Clone());
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int index = j * stride + 4 * i;
                    Color oldColor = bmp.GetPixel(i, j), color;
                    if (ColorFormat.Equals(EColorFormat.GrayScale))
                    {
                        int R = (pixels[index] <= p1) ? 0 : LUT[0].Length - 1 , G, B;
                        G = B = R;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    else
                    {
                        int R = (pixels[index] <= p1) ? 0 : LUT[0].Length - 1, 
                            G = (pixels[index + 1] <= p1) ? 0 : LUT[1].Length - 1, 
                            B = (pixels[index + 2] <= p1) ? 0 : LUT[1].Length - 1;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            ReloadBitmap();
        }
        public void OnePBinaryThresholingWithKeepingL(int p1)
        {
            if (imgCopy == null)
                imgCopy = bitmapImg.Clone();
            byte[] pixels = Utils.GetPixels(imgCopy.Clone());
            int stride = Width * 4;
            int size = Height * stride;
            Bitmap bmp = Utils.BitmapImage2Bitmap(imgCopy.Clone());
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int index = j * stride + 4 * i;
                    Color oldColor = bmp.GetPixel(i, j), color;
                    if (ColorFormat.Equals(EColorFormat.GrayScale))
                    {
                        int R = (pixels[index] <= p1) ? pixels[index] : LUT[0].Length - 1, G, B;
                        G = B = R;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    else
                    {
                        int R = (pixels[index] <= p1) ? pixels[index] : LUT[0].Length - 1,
                            G = (pixels[index + 1] <= p1) ? pixels[index+1] : LUT[1].Length - 1,
                            B = (pixels[index + 2] <= p1) ? pixels[index+2] : LUT[1].Length - 1;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            ReloadBitmap();
        }
        public void TwoPBinaryThresholing(int p1, int p2)
        {
            if (imgCopy == null)
                imgCopy = bitmapImg.Clone();
            byte[] pixels = Utils.GetPixels(imgCopy.Clone());
            int stride = Width * 4;
            int size = Height * stride;
            Bitmap bmp = Utils.BitmapImage2Bitmap(imgCopy.Clone());
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int index = j * stride + 4 * i;
                    Color oldColor = bmp.GetPixel(i, j), color;
                    if (ColorFormat.Equals(EColorFormat.GrayScale))
                    {
                        int R = (pixels[index] >= p1 && pixels[index] <= p2) ? 0 : LUT[0].Length - 1, G, B;
                        G = B = R;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    else
                    {
                        int R = (pixels[index] >= p1 && pixels[index] <= p2) ? 0 : LUT[0].Length - 1,
                            G = (pixels[index + 1] >= p1 && pixels[index + 1] <= p2) ? 0 : LUT[1].Length - 1,
                            B = (pixels[index + 2] >= p1 && pixels[index + 2] <= p2) ? 0 : LUT[1].Length - 1;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            ReloadBitmap();
        }
        public void TwoPBinaryThresholingWithKeepingL(int p1, int p2)
        {
            if (imgCopy == null)
                imgCopy = bitmapImg.Clone();
            byte[] pixels = Utils.GetPixels(imgCopy.Clone());
            int stride = Width * 4;
            int size = Height * stride;
            Bitmap bmp = Utils.BitmapImage2Bitmap(imgCopy.Clone());
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int index = j * stride + 4 * i;
                    Color oldColor = bmp.GetPixel(i, j), color;
                    if (ColorFormat.Equals(EColorFormat.GrayScale))
                    {
                        int R = (pixels[index] >= p1 && pixels[index] <= p2) ? pixels[index] : LUT[0].Length - 1, G, B;
                        G = B = R;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    else
                    {
                        int R = (pixels[index] >= p1 && pixels[index] <= p2) ? pixels[index] : LUT[0].Length - 1,
                            G = (pixels[index + 1] >= p1 && pixels[index + 1] <= p2) ? pixels[index + 1] : LUT[1].Length - 1,
                            B = (pixels[index + 2] >= p1 && pixels[index + 2] <= p2) ? pixels[index + 2] : LUT[1].Length - 1;
                        color = Color.FromArgb(oldColor.A, R, G, B);
                    }
                    bmp.SetPixel(i, j, color);
                }
            }
            bitmapImg = Utils.BitmapToImageSource(bmp);
            ReloadBitmap();
        }
        public void RestoreCopyIfExists()
        {
            if(imgCopy != null)
            {
                bitmapImg = imgCopy;
                imgCopy = null;
                FindLUT(bitmapImg);
                ReloadCulumatedHistIfExists();
                ReloadBitmap();
            }
        }
        public void RemoveCopyIfExists()
        {
            bitmapImg = imgCopy;
            imgCopy = null;
        }
        public void LuminanceLevelReduction(int levels)
        {
            int pwith = LUT[0].Length / levels, level = 0;
            for (int i = 0; i < colorsNum; i++)
            {
                ColorRedirect[i][0] = (uint)level;
                for (int j = 1; j < LUT[0].Length; j++)
                {
                    ColorRedirect[i][j] = (uint) level;
                    if (j % pwith == 0) level += (pwith - 1);
                }
            }
            ReloadBitmap();
        }
    }
}