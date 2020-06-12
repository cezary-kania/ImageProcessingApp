using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu;
using Emgu.CV.Structure;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Linq;
using System.Windows.Data;
using Emgu.CV.Dnn;
using Emgu.CV.ML;
using Emgu.CV.ML.MlEnum;
using System.Windows.Media.TextFormatting;
using System.Reflection.Emit;

namespace ImageProcessingApp.Models
{
    public static class ImageOperations
    {
        public static class HistogramOperations
        {
            public static void Equalization(Image img)
            {
                int[][] imgLUT = img.FindLookUpTable();
                int[][] ColorRedirect = new int[][] { new int[256], new int[256], new int[256], };
                for (int k = 0; k < img.colorsNum; k++)
                {
                    int[] oldLUT = imgLUT[k];
                    double[] D = new double[oldLUT.Length];
                    double sum = img.Width * img.Height;
                    for (int i = 0; i < D.Length; i++)
                        D[i] = Convert.ToDouble(oldLUT[i]) / sum;
                    for (int i = 1; i < D.Length; i++)
                        D[i] = D[i - 1] + D[i];
                    for (int i = 0; i < oldLUT.Length; i++)
                        ColorRedirect[k][i] = (int) (D[i] * (oldLUT.Length - 1));
                }
                Bitmap bmp = img.Bitmap;
                for (int x = 0; x < bmp.Width; ++x)
                {
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        Color oldColor = bmp.GetPixel(x, y);
                        int[] colors;
                        if (img.colorsNum == 3)
                            colors = new int[] {ColorRedirect[0][oldColor.R],ColorRedirect[1][oldColor.G], ColorRedirect[2][oldColor.B],};
                        else    
                            colors = new int[] {ColorRedirect[0][oldColor.R],ColorRedirect[0][oldColor.G], ColorRedirect[0][oldColor.B],};
                        Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
            public static void Stretching(Image img)
            {
                int Lmin = 0, Lmax = 255,
                     max = Lmax, min = Lmin;
                int[][] imgLUT = img.FindLookUpTable();
                int[][] ColorRedirect = new int[][] { new int[256], new int[256], new int[256], };
                for (int k = 0; k < img.colorsNum; k++)
                {
                    for (int i = 0; i < 256; i++)
                    {
                        if (min == Lmin && imgLUT[k][i] > 0) min = i;
                        if (max == Lmax && imgLUT[k][Lmax - i] > 0) max = Lmax - i;
                    }
                    for (int i = 0; i < 256; i++)
                    {
                        if (i < min)
                            ColorRedirect[k][i] = Lmin;
                        else if (i > max)
                            ColorRedirect[k][i] = Lmax;
                        else
                            ColorRedirect[k][i] = (i - min) * Lmax / ((max - min == 0) ? 1 : max - min);
                    }
                }
                Bitmap bmp = img.Bitmap;
                for (int x = 0; x < bmp.Width; ++x)
                {
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        Color oldColor = bmp.GetPixel(x, y);
                        int[] colors;
                        if (img.colorsNum == 3)
                            colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[1][oldColor.G], ColorRedirect[2][oldColor.B], };
                        else
                            colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[0][oldColor.G], ColorRedirect[0][oldColor.B], };
                        Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
            public static void HistAlignment(Image img)
            {
                int[][] imgLUT = img.FindLookUpTable();
                int[][] ColorRedirect = new int[][] { new int[256], new int[256], new int[256], };
                for (int k = 0; k < img.colorsNum; k++)
                {
                    int[] oldLUT = imgLUT[k];
                    double[] D = new double[oldLUT.Length];
                    D[0] = oldLUT[0];
                    for (int i = 1; i < D.Length; i++)
                        D[i] = D[i - 1] + oldLUT[i];
                    double firstNonZero = 0, sum = img.Width * img.Height;
                    for (int i = 0; i < D.Length; i++)
                    {
                        D[i] /= sum;
                        if (firstNonZero == 0 && D[i] != 0) firstNonZero = D[i];
                    }
                    for (int i = 0; i < oldLUT.Length; i++)
                        ColorRedirect[k][i] = (int)Math.Round((D[i] - firstNonZero) / (1.0 - firstNonZero) * (oldLUT.Length - 1));
                }
                Bitmap bmp = img.Bitmap;
                for (int x = 0; x < bmp.Width; ++x)
                {
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        Color oldColor = bmp.GetPixel(x, y);
                        int[] colors;
                        if (img.colorsNum == 3)
                            colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[1][oldColor.G], ColorRedirect[2][oldColor.B], };
                        else
                            colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[0][oldColor.G], ColorRedirect[0][oldColor.B], };
                        Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
        }
        public static class TwoArgsOperations
        {
            public static Bitmap Add(Bitmap bmp1, Bitmap bmp2)
            {
                int width = Math.Min(bmp1.Width, bmp2.Width);
                int height = Math.Min(bmp1.Height, bmp2.Height);
                Bitmap bmp = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        Color color2 = bmp2.GetPixel(i, j);
                        byte R1 = color1.R, G1 = color1.G, B1 = color1.B,
                             R2 = color2.R, G2 = color2.G, B2 = color2.B;
                        int R = Math.Min(255, R1 + R2),
                            G = Math.Min(255, G1 + G2),
                            B = Math.Min(255, B1 + B2);
                        bmp.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
                return bmp;
            }
            public static Bitmap Blending(Bitmap bmp1, Bitmap bmp2, double blendingRatio)
            {
                blendingRatio = Math.Max(Math.Min(1, blendingRatio), 0);
                int width = Math.Min(bmp1.Width, bmp2.Width);
                int height = Math.Min(bmp1.Height, bmp2.Height);
                Bitmap bmp = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        Color color2 = bmp2.GetPixel(i, j);
                        byte R1 = color1.R, G1 = color1.G, B1 = color1.B;
                        byte R2 = color2.R, G2 = color2.G, B2 = color2.B;
                        byte outR = (byte) (blendingRatio * R1 + (1 - blendingRatio) * R2);
                        byte outG = (byte) (blendingRatio * G1 + (1 - blendingRatio) * G2);
                        byte outB = (byte) (blendingRatio * B1 + (1 - blendingRatio) * B2);
                        bmp.SetPixel(i, j, Color.FromArgb(outR, outG, outB));
                    }
                }
                return bmp;
            }
            public static Bitmap AND(Bitmap bmp1, Bitmap bmp2)
            {
                int width = Math.Min(bmp1.Width, bmp2.Width);
                int height = Math.Min(bmp1.Height, bmp2.Height);
                Bitmap bmp = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        Color color2 = bmp2.GetPixel(i, j);
                        byte R1 = color1.R, G1 = color1.G, B1 = color1.B;
                        byte R2 = color2.R, G2 = color2.G, B2 = color2.B;
                        bmp.SetPixel(i, j, Color.FromArgb(R1 & R2, G1 & G2, B1 & B2));
                    }
                }
                return bmp;
            }
            public static Bitmap XOR(Bitmap bmp1, Bitmap bmp2)
            {
                int width = Math.Min(bmp1.Width, bmp2.Width);
                int height = Math.Min(bmp1.Height, bmp2.Height);
                Bitmap bmp = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        Color color2 = bmp2.GetPixel(i, j);
                        byte R1 = color1.R, G1 = color1.G, B1 = color1.B;
                        byte R2 = color2.R, G2 = color2.G, B2 = color2.B;
                        bmp.SetPixel(i, j, Color.FromArgb(R1 ^ R2, G1 ^ G2, B1 ^ B2));
                    }
                }
                return bmp;
            }
            public static Bitmap OR(Bitmap bmp1, Bitmap bmp2)
            {
                int width = Math.Min(bmp1.Width, bmp2.Width);
                int height = Math.Min(bmp1.Height, bmp2.Height);
                Bitmap bmp = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        Color color2 = bmp2.GetPixel(i, j);
                        byte R1 = color1.R, G1 = color1.G, B1 = color1.B;
                        byte R2 = color2.R, G2 = color2.G, B2 = color2.B;
                        bmp.SetPixel(i, j, Color.FromArgb(R1 | R2, G1 | G2, B1 | B2));
                    }
                }
                return bmp;
            }
            public static Bitmap NOT(Bitmap bmp)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color color = bmp.GetPixel(i, j);
                        byte R = color.R, G = color.G, B = color.B;
                        bmp.SetPixel(i, j, Color.FromArgb(Math.Max(0, (int)unchecked((byte)~R)),
                                                            Math.Max(0, (int)unchecked((byte)~G)),
                                                            Math.Max(0, (int)unchecked((byte)~B))
                                                          ));
                    }
                }
                return bmp;
            }
        }
        public static class EmguPointOperations
        {
            public static Bitmap Add(Bitmap bmp1, Bitmap bmp2)
            {
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp1),
                         bmp2Arr = Utils.BmpToArray(bmp2);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr),
                                 img2 = new Image<Bgr, Byte>(bmp2Arr);
                img2 = img2.Resize(img.Width, img.Height, Emgu.CV.CvEnum.Inter.Linear);
                img = img.Add(img2);
                return Utils.EmguImgToBmp(img.Data);
            }
            public static Bitmap AND(Bitmap bmp1, Bitmap bmp2)
            {
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp1),
                         bmp2Arr = Utils.BmpToArray(bmp2);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr),
                                 img2 = new Image<Bgr, Byte>(bmp2Arr);
                img2 = img2.Resize(img.Width, img.Height, Emgu.CV.CvEnum.Inter.Linear);
                img = img.And(img2);
                return Utils.EmguImgToBmp(img.Data);
            }
            public static Bitmap XOR(Bitmap bmp1, Bitmap bmp2)
            {
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp1),
                        bmp2Arr = Utils.BmpToArray(bmp2);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr),
                                 img2 = new Image<Bgr, Byte>(bmp2Arr);
                img2 = img2.Resize(img.Width, img.Height, Emgu.CV.CvEnum.Inter.Linear);
                img = img.Xor(img2);
                return Utils.EmguImgToBmp(img.Data);
            }
            public static Bitmap OR(Bitmap bmp1, Bitmap bmp2)
            {
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp1),
                        bmp2Arr = Utils.BmpToArray(bmp2);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr),
                                 img2 = new Image<Bgr, Byte>(bmp2Arr);
                img2 = img2.Resize(img.Width, img.Height, Emgu.CV.CvEnum.Inter.Linear);
                img = img.Or(img2);
                return Utils.EmguImgToBmp(img.Data);
            }
            public static Bitmap Blending(Bitmap bmp1, Bitmap bmp2, object param)
            {
                object[] parametersTb = (object[])param;
                double alpha = (double) parametersTb[0], 
                       beta = (double) parametersTb[1], 
                       gamma = (double)parametersTb[2];
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp1),
                         bmp2Arr = Utils.BmpToArray(bmp2);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr),
                                 img2 = new Image<Bgr, Byte>(bmp2Arr);
                img2 = img2.Resize(img.Width, img.Height, Emgu.CV.CvEnum.Inter.Linear);
                img = img.AddWeighted(img2, alpha, beta, gamma);
                return Utils.EmguImgToBmp(img.Data);
            }
            public static Bitmap NOT(Bitmap bmp)
            {
                byte[,,] bmp1Arr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmp1Arr);
                img = img.Not();
                return Utils.EmguImgToBmp(img.Data);
            }
        }
        public static class EmguNeighborhoodOp
        {
            private static Dictionary<string, Emgu.CV.CvEnum.BorderType> borderDict = new Dictionary<string, Emgu.CV.CvEnum.BorderType>()
            {
                {"replicate",Emgu.CV.CvEnum.BorderType.Replicate },
                {"reflect",Emgu.CV.CvEnum.BorderType.Reflect },
                {"isolated",Emgu.CV.CvEnum.BorderType.Isolated },
            };
            public static Bitmap Blur(Bitmap bmp, string borderOperation)
            {
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, byte>(img.Size);
                CvInvoke.Blur(img, dst,new Size(3,3),new Point(-1,-1), borderType: borderDict[borderOperation]);
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap GaussianBlur(Bitmap bmp, string borderOperation)
            {                
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, byte>(img.Size);
                CvInvoke.GaussianBlur(img, dst, new Size(3, 3), sigmaX: 0, borderType: borderDict[borderOperation]);
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap MedianBlur(Bitmap bmp, int ksize, string borderOperation)
            {
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, byte>(img.Size);
                CvInvoke.MedianBlur(img, dst, ksize);
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap Sobel(Bitmap bmp, string borderOperation)
            {
                string file1 = Utils.SaveBmpTmp(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file1), dst = new Image<Bgr, byte>(img.Size);
                Image<Bgr, float> sobelX = new Image<Bgr, float>(img.Size), sobelY = new Image<Bgr, float>(img.Size); ;
                CvInvoke.Sobel(img, sobelX, Emgu.CV.CvEnum.DepthType.Cv64F, 1, 0, 5, borderType: borderDict[borderOperation]);
                CvInvoke.Sobel(img, sobelY, Emgu.CV.CvEnum.DepthType.Cv64F, 0, 1, 5, borderType: borderDict[borderOperation]);
                CvInvoke.HConcat(sobelX, sobelY, dst);
                dst.Save(file1);
                Bitmap tmpBmp = Utils.BmpFromFile(file1);
                File.Delete(file1);
                return tmpBmp;
            }
            public static Bitmap Laplacian(Bitmap bmp, string borderOperation)
            {
                string file1 = Utils.SaveBmpTmp(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file1),
                                 dst = new Image<Bgr, Byte>(img.Size);
                CvInvoke.Laplacian(img, dst, Emgu.CV.CvEnum.DepthType.Cv64F, borderType: borderDict[borderOperation]);
                dst.Save(file1);
                Bitmap tmpBmp = Utils.BmpFromFile(file1);
                File.Delete(file1);
                return tmpBmp;
            }
            public static Bitmap Canny(Bitmap bmp, int th1, int th2)
            {
                string file1 = Utils.SaveBmpTmp(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file1), dst = new Image<Bgr, Byte>(img.Size);
                CvInvoke.Canny(img, dst, th1, th2);
                dst.Save(file1);
                Bitmap tmpBmp = Utils.BmpFromFile(file1);
                File.Delete(file1);
                return tmpBmp;
            }
            public static Bitmap Filter2D(Bitmap bmp, float[,] mask, string borderOperation)
            {
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, byte>(img.Size);
                ConvolutionKernelF kernel = new ConvolutionKernelF(mask);
                CvInvoke.Filter2D(img, dst, kernel, new Point(-1, -1), borderType: borderDict[borderOperation]);
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static float[,] MasksConvolution(float[,] mask3x3_1, float[,] mask3x3_2)
            {
                float[,] f = new float[7, 7],
                         mask5x5_output = new float[5, 5];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        f[i + 2, j + 2] = mask3x3_1[i, j];
                for (int z = 0; z < 5; ++z)
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 3; j++)
                            for (int k = 0; k < 3; k++)
                                mask5x5_output[z, i] += mask3x3_2[j, k] * f[j + z, k + i];
                return mask5x5_output;
            }
        }
        public static void ImageNegation(Image img)
        {
            Bitmap bmp = img.Bitmap;
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    Color newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    bmp.SetPixel(x, y, newColor);
                }
            }
        }
        public static void OnePBinaryThresholing(Image img, int p1)
        {
            Bitmap bmp = img.Bitmap;
            ColorBitmapToGrayS(bmp);
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int[] colors = new int[]
                    {
                        (oldColor.R <= p1) ? 0 : 255,
                        (oldColor.G <= p1) ? 0 : 255,
                        (oldColor.B <= p1) ? 0 : 255,
                    };
                    Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    bmp.SetPixel(x, y, newColor);
                }
            }
        }
        public static void OnePBinaryThresholingWithKeepingL(Image img, int p1)
        {
            Bitmap bmp = img.Bitmap;
            ColorBitmapToGrayS(bmp);
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int[] colors = new int[]
                    {
                        (oldColor.R <= p1) ? oldColor.R : 255,
                        (oldColor.G <= p1) ? oldColor.G : 255,
                        (oldColor.B <= p1) ? oldColor.B : 255,
                    };
                    Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    bmp.SetPixel(x, y, newColor);
                }
            }
        }
        public static void Posterize(Image img, int levels)
        {
            int pwith = 256 / levels, level;
            int[][] ColorRedirect = new int[][] {new int[256], new int[256], new int[256],};
            for (int i = 0; i < img.colorsNum; i++)
            {
                level = 0;
                for (int j = 0; j < 256; j++)
                {
                    ColorRedirect[i][j] = Math.Min(level, 255);
                    if (j != 0 && j % pwith == 0)
                    {
                        if (level == 0) level += (pwith - 1);
                        level += pwith;
                    }
                }
            }
            Bitmap bmp = img.Bitmap;
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int[] colors;
                    if (img.colorsNum == 3)
                        colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[1][oldColor.G], ColorRedirect[2][oldColor.B], };
                    else
                        colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[0][oldColor.G], ColorRedirect[0][oldColor.B], };
                    Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    bmp.SetPixel(x, y, newColor);
                }
            }
        }
        public static void RangeStretching(Image img, uint p1, uint p2, uint q3, uint q4)
        {
            int Lmin = 0, Lmax = (int) (q4 - q3),
                     max = Lmax, min = Lmin;
            int[][] imgLUT = img.FindLookUpTable();
            int[][] ColorRedirect = new int[][] { new int[256], new int[256], new int[256], };
            for (int i = 0; i < ColorRedirect.Length; i++)
                for (int j = 0; j < ColorRedirect[i].Length; j++) ColorRedirect[i][j] = j;
            for (int k = 0; k < img.colorsNum; k++)
            {
                for (int i = 0; i < 256; i++)
                {
                    if (min == Lmin && imgLUT[k][i] > 0) min = i;
                    if (max == Lmax && imgLUT[k][Lmax - i] > 0) max = Lmax - i;
                }
                max = Math.Min((int) p2, max);
                min = Math.Max((int) p1, min);
                for (int i = (int) p1; i < p2; i++)
                {
                    if (i < min)
                        ColorRedirect[k][i] = Math.Min(Lmin + (int)q3, 255);
                    else if (i > max)
                        ColorRedirect[k][i] = Math.Min(Lmax + (int)q3, 255);
                    else
                        ColorRedirect[k][i] = Math.Min((i - min) * Lmax / ((max - min == 0) ? 1 : max - min) + (int)q3, 255);
                }
            }
            Bitmap bmp = img.Bitmap;
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int[] colors;
                    if (img.colorsNum == 3)
                        colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[1][oldColor.G], ColorRedirect[2][oldColor.B], };
                    else
                        colors = new int[] { ColorRedirect[0][oldColor.R], ColorRedirect[0][oldColor.G], ColorRedirect[0][oldColor.B], };
                    Color newColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    bmp.SetPixel(x, y, newColor);
                }
            }
        }
        public static void ColorBitmapToGrayS(Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color oldColor = bmp.GetPixel(x, y);
                    int gray = (oldColor.R + oldColor.G + oldColor.B) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
        }
        public static Bitmap SegmentAndCountObjs(Bitmap bmp, out int counter, int[] th1, int[] th2)
        {
            counter = 0;
            string file1 = Utils.SaveBmpTmp(bmp); // zaladowanie obrazu przez przeladowanie do pliku 
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(file1);
            Image<Gray, Byte> mask = new Image<Gray, Byte>(img.Size);
            ScalarArray lowerB = new ScalarArray(new MCvScalar(th1[2], th1[1], th1[0]));
            ScalarArray upperB = new ScalarArray(new MCvScalar(th2[2], th2[1], th2[0]));
            CvInvoke.InRange(img, lowerB, upperB, mask);
            Image<Gray, Byte> img_gray = new Image<Gray, Byte>(img.Size);
            CvInvoke.CvtColor(img, img_gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            Image<Gray, Byte> thresh = new Image<Gray, Byte>(img.Size),
                              inv_thresh = new Image<Gray, Byte>(img.Size);
            CvInvoke.Threshold(img_gray, inv_thresh, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
            CvInvoke.BitwiseNot(inv_thresh, thresh);

            // Odszumianie
            ConvolutionKernelF kernelF = new ConvolutionKernelF(new float[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            Image<Gray, Byte> opening = new Image<Gray, Byte>(img.Size), blured = new Image<Gray, byte>(img.Size);
            CvInvoke.MorphologyEx(mask, opening, Emgu.CV.CvEnum.MorphOp.Open, kernelF, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

            CvInvoke.MedianBlur(opening, blured, 7);
            // Wyznaczenie jednoznacznych obszarów tła
            Image<Gray, Byte> sure_bg = new Image<Gray, Byte>(img.Size);
            CvInvoke.Dilate(blured, sure_bg, kernelF, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());
            // Wyznaczanie jednoznacznych obszarów obiektów

            // Krok pośredni: transformata odległościowa 
            Image<Gray, Byte> dist_transform = new Image<Gray, Byte>(img.Size);
            CvInvoke.DistanceTransform(blured, dist_transform, null, Emgu.CV.CvEnum.DistType.L2, 5);

            dist_transform.Save(file1);
            dist_transform = new Image<Gray, byte>(file1);
            // określenie jednoznacznych obszarów obiektów przez progowanie obrazu transformaty odlegościowej

            double locMin = 0, locMax = 0;
            Point maxPoint = new Point(), minPoint = new Point();
            CvInvoke.MinMaxLoc(dist_transform, ref locMin, ref locMax, ref minPoint, ref maxPoint);

            Image<Gray, Byte> sure_fg = new Image<Gray, Byte>(img.Size);
            CvInvoke.Threshold(dist_transform, sure_fg, 0.5 * locMax, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            sure_fg = sure_fg.Convert<Gray, Byte>();
            // Wyznaczanie obszarów niepewnych
            // takich w których znajdują się krawędzie obiektu
            // Obraz uzyskujemy przez odjęcie obszarów jednoznacznych
            Image<Gray, Byte> unknown = new Image<Gray, Byte>(img.Size);
            CvInvoke.Subtract(sure_bg, sure_fg, unknown, dtype: Emgu.CV.CvEnum.DepthType.Cv8U);

            // Etykietowanie obiektów
            
            Mat labels = new Mat();
            counter = CvInvoke.ConnectedComponents(sure_fg, labels) - 1; // obliczenie wystapien obiektow i odjecie tla 
            Array labelsData = labels.GetData();
            // dodanie wartości 1 do etykiet, tak aby tło miało wartośc 1 a nie 0.
            Image<Gray, Byte> markers = new Image<Gray, Byte>(img.Size);
            for (int i = 0; i < markers.Rows; i++)
                for (int j = 0; j < markers.Cols; j++)
                {
                    byte l_value = Convert.ToByte((int)labelsData.GetValue(i, j));
                    markers.Data.SetValue(++l_value, i, j, 0);
                }
            // oznaczenie obszarów niepewnych jako zero
            for (int i = 0; i < unknown.Rows; i++)
            {
                for (int j = 0; j < unknown.Cols; j++)
                {
                    byte unknown_value = (byte)unknown.Data.GetValue(i, j, 0);
                    if (unknown_value == 255)
                    {
                        markers.Data.SetValue((byte)0, i, j, 0);
                    }
                }
            }
            markers.Save(file1); // przeladowanie wymuszone przez emguCV (bez tego obraz jest czarny) 
            Image<Gray, Int32> markers2 = new Image<Gray, Int32>(file1);
            CvInvoke.Watershed(img, markers2);
            for (int i = 0; i < markers2.Rows; i++)
            {
                for (int j = 0; j < markers2.Cols; j++)
                {
                    int markers2_value = (int)markers2.Data.GetValue(i, j, 0);
                    if (markers2_value == -1)
                    {
                        img.Data.SetValue((byte)255, i, j, 0);
                        img.Data.SetValue((byte)0, i, j, 1);
                        img.Data.SetValue((byte)0, i, j, 2);
                    }
                }
            }
            return Utils.EmguImgToBmp(img.Data);
        }
        public static class MorphologicalOperations
        {
            private static Dictionary<string, Emgu.CV.CvEnum.BorderType> borderDict = new Dictionary<string, Emgu.CV.CvEnum.BorderType>()
            {
                {"replicate",Emgu.CV.CvEnum.BorderType.Replicate },
                {"reflect",Emgu.CV.CvEnum.BorderType.Reflect },
                {"isolated",Emgu.CV.CvEnum.BorderType.Isolated },
            };
            private static byte[,] GetDiamondSel(int r)
            {
                byte[,] element = new byte[2 * r + 1, 2 * r + 1];
                for (int i = 0; i < r; i++)
                {
                    int j;
                    for (j = 0; j < r - i; j++)
                        element[i, j] = 0;
                    for (; j < r + i + 1; j++)
                        element[i, j] = 1;
                    for (j = r + 1 + i; j < 2 * r + 1; j++)
                        element[i, j] = 0;
                }
                for (int i = 0; i < 2 * r + 1; i++)
                    element[r, i] = 1;
                for (int i = 0; i < r; i++)
                {
                    int j;
                    for (j = 0; j < i + 1; j++)
                        element[i + r + 1, j] = 0;
                    for (int k = 0; k < 2 * r + 1 - 2 * (i + 1); j++, k++)
                        element[i + r + 1, j] = 1;
                    for (; j < 2 * r + 1; j++)
                        element[i + r + 1, j] = 0;
                }
                return element;
            }
            public static bool CheckIfBinary(Bitmap bmp)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    for (int y = 0; y < bmp.Height; ++y)
                    {
                        Color color = bmp.GetPixel(x, y);
                        if ((color.R != 255 && color.R != 0) || (color.G != 255 && color.G != 0) || (color.B != 255 && color.B != 0))
                            return false;
                    }
                }
                return true;
            }
            public static Bitmap Erosion(Bitmap bmp, string element,int elementRadius, string borderOperation)
            {
                Mat structuringElement;
                if (element.Equals("quad"))
                    structuringElement = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(elementRadius, elementRadius), new Point(-1, -1));
                else
                    structuringElement = new Matrix<byte>(GetDiamondSel(elementRadius)).Mat;
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr),
                                  dst = new Image<Gray, byte>(img.Size);
                CvInvoke.Erode(img, dst, structuringElement, new Point(-1, -1), 1, borderType: borderDict[borderOperation],new MCvScalar());
                return Utils.EmguImgToGrayBmp(dst.Data);
            }
            public static Bitmap Dilation(Bitmap bmp, string element, int elementRadius, string borderOperation)
            {
                Mat structuringElement;
                if (element.Equals("quad"))
                    structuringElement = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(elementRadius, elementRadius), new Point(-1, -1));
                else
                    structuringElement = new Matrix<byte>(GetDiamondSel(elementRadius)).Mat;
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, Byte>(img.Size);
                CvInvoke.Dilate(img, dst, structuringElement, new Point(-1, -1), 1, borderType: borderDict[borderOperation], new MCvScalar());
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap Closing(Bitmap bmp, string element, int elementRadius, string borderOperation)
            {
                Mat structuringElement;
                if (element.Equals("quad"))
                    structuringElement = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(elementRadius, elementRadius), new Point(-1, -1));
                else
                    structuringElement = new Matrix<byte>(GetDiamondSel(elementRadius)).Mat;
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, Byte>(img.Size);
                CvInvoke.MorphologyEx(img, dst, Emgu.CV.CvEnum.MorphOp.Close, structuringElement, new Point(-1, -1), 1, borderType: borderDict[borderOperation], new MCvScalar());
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap Opening(Bitmap bmp, string element, int elementRadius, string borderOperation)
            {
                Mat structuringElement;
                if (element.Equals("quad"))
                    structuringElement = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(elementRadius, elementRadius), new Point(-1, -1));
                else
                    structuringElement = new Matrix<byte>(GetDiamondSel(elementRadius)).Mat;
                byte[,,] bmpArr = Utils.BmpToArray(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(bmpArr),
                                 dst = new Image<Bgr, Byte>(img.Size);
                CvInvoke.MorphologyEx(img, dst, Emgu.CV.CvEnum.MorphOp.Open, structuringElement, new Point(-1, -1), 1, borderType: borderDict[borderOperation], new MCvScalar());
                return Utils.EmguImgToBmp(dst.Data);
            }
            public static Bitmap Skeletonization(Bitmap bmp, string borderOperation)
            {

                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr);
                //Step 1
                Size size = img.Size;
                Image<Gray, Byte> skel = new Image<Gray, byte>(size),
                                  im_copy = img.Copy();
                //Create Kernel
                Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(3, 3), new Point(-1,-1));
                //loop for 2-4 steps
                while(true)
                {
                    // Step 2
                    Image<Gray, Byte> im_open = new Image<Gray, byte>(size);
                    CvInvoke.MorphologyEx(im_copy, im_open, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 1, borderType: borderDict[borderOperation], new MCvScalar());
                    // Step 3
                    Image<Gray, Byte> im_temp = new Image<Gray, byte>(size);
                    CvInvoke.Subtract(im_copy, im_open, im_temp);
                    // Step 4
                    Image<Gray, Byte> im_eroded = new Image<Gray, byte>(size);
                    CvInvoke.Erode(im_copy, im_eroded, kernel, new Point(-1, -1), 1, borderType: borderDict[borderOperation], new MCvScalar());
                    // Skeleton update
                    CvInvoke.BitwiseOr(skel, im_temp, skel);
                    im_copy = im_eroded.Copy();
                    // Step 5
                    if (CvInvoke.CountNonZero(im_copy) == 0)
                        break;
                }
                return Utils.EmguImgToGrayBmp(skel.Data);
            }
        }
        public static class Lab5_th
        {
            public static Bitmap InteractiveThresholding(Bitmap bmp, int th)
            {
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr),
                                  dst = new Image<Gray, byte>(img.Size);
                CvInvoke.Threshold(img, dst, th, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                return Utils.EmguImgToGrayBmp(dst.Data);
            }
            public static Bitmap AdaptiveThresholding(Bitmap bmp)
            {
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr),
                                  dst = new Image<Gray, byte>(img.Size);
                CvInvoke.AdaptiveThreshold(img, dst, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, 11, 5);
                return Utils.EmguImgToGrayBmp(dst.Data);
            }
            public static Bitmap OtsuThresholding(Bitmap bmp)
            {
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr),
                                 dst = new Image<Gray, Byte>(img.Size),
                                 blur = new Image<Gray, Byte>(img.Size);
                CvInvoke.GaussianBlur(img, blur, new Size(5, 5), 0);
                CvInvoke.Threshold(blur, dst, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
                return Utils.EmguImgToGrayBmp(dst.Data);
            }
            public static Bitmap WatershedThresholding(Bitmap bmp)
            {
                string file1 = Utils.SaveBmpTmp(bmp);
                Image<Bgr, Byte> img = new Image<Bgr, Byte>(file1);
                ///////
                Image<Gray, Byte> img_gray = new Image<Gray, Byte>(img.Size);
                CvInvoke.CvtColor(img, img_gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Image<Gray, Byte> thresh = new Image<Gray, Byte>(img.Size),
                                  inv_thresh = new Image<Gray, Byte>(img.Size);
                CvInvoke.Threshold(img_gray, inv_thresh, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
                CvInvoke.BitwiseNot(inv_thresh, thresh);
                //CvInvoke.Threshold(thresh, dst, 0, 255, Emgu.CV.CvEnum.ThresholdType.BinaryInv);

                // Odszumianie
                ConvolutionKernelF kernelF = new ConvolutionKernelF(new float[,] { { 1, 1, 1}, { 1, 1, 1 }, { 1, 1, 1 } });
                Image<Gray, Byte> opening = new Image<Gray, Byte>(img.Size);
                CvInvoke.MorphologyEx(thresh, opening, Emgu.CV.CvEnum.MorphOp.Open, kernelF, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

                // Wyznaczenie jednoznacznych obszarów tła
                Image<Gray, Byte> sure_bg = new Image<Gray, Byte>(img.Size);
                CvInvoke.Dilate(opening, sure_bg, kernelF, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());
                // Wyznaczanie jednoznacznych obszarów obiektów

                // Krok pośredni: transformata odległościowa 
                Image<Gray, Byte> dist_transform = new Image<Gray, Byte>(img.Size);
                CvInvoke.DistanceTransform(opening, dist_transform, null, Emgu.CV.CvEnum.DistType.L2, 5);

                ////////////////////
                ///// Convert doesnt work, depth is still 32f
                //dist_transform = dist_transform.Convert<Gray, byte>();
                dist_transform.Save(file1);
                dist_transform = new Image<Gray, byte>(file1);
                // określenie jednoznacznych obszarów obiektów przez progowanie obrazu transformaty odlegościowej

                double locMin =0, locMax = 0;
                Point maxPoint = new Point(), minPoint = new Point();
                CvInvoke.MinMaxLoc(dist_transform, ref locMin, ref locMax, ref minPoint, ref maxPoint);
                Image<Gray, Byte> sure_fg = new Image<Gray, Byte>(img.Size);
                CvInvoke.Threshold(dist_transform, sure_fg, 0.5 * locMax, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                sure_fg = sure_fg.Convert<Gray, Byte>();
                // Wyznaczanie obszarów niepewnych
                // takich w których znajdują się krawędzie obiektu
                // Obraz uzyskujemy przez odjęcie obszarów jednoznacznych
                Image<Gray, Byte> unknown = new Image<Gray, Byte>(img.Size);
                CvInvoke.Subtract(sure_bg, sure_fg, unknown, dtype : Emgu.CV.CvEnum.DepthType.Cv8U);

                // Etykietowanie obiektów
                //Mat markers = new Mat(img.Size, Emgu.CV.CvEnum.DepthType.Cv32S, sure_fg.NumberOfChannels);
                //Image<Gray, Byte> markers = new Image<Gray, Byte>(img.Size);
                //Mat markers = new Mat();
                Image<Gray, Byte> markers = new Image<Gray, Byte>(img.Size);
                Mat labels = new Mat();
                int counter = CvInvoke.ConnectedComponents(sure_fg, labels);
                // dodanie wartości 1 do etykiet, tak aby tło miało wartośc 1 a nie 0.
                Array labelsData = labels.GetData();
                for (int i = 0; i < labels.Rows; i++)
                    for (int j = 0; j < labels.Cols; j++)
                    {
                        byte l_value = Convert.ToByte( (int) labelsData.GetValue(i, j));
                        markers.Data.SetValue(++l_value, i, j, 0);
                    }
                        
                // oznaczenie obszarów niepewnych jako zero
                for (int i = 0; i < unknown.Rows; i++)
                {
                    for (int j = 0; j < unknown.Cols; j++)
                    {
                        byte unknown_value = (byte) unknown.Data.GetValue(i, j,0);
                        if (unknown_value == 255)
                        {
                            markers.Data.SetValue((byte) 0, i, j,0);
                        }   
                    }
                }
                markers.Save(file1);
                Image<Gray, Int32> markers2 = new Image<Gray, Int32>(file1);
                CvInvoke.Watershed(img, markers2);
                for (int i = 0; i < markers2.Rows; i++)
                {
                    for (int j = 0; j < markers2.Cols; j++)
                    {
                        int markers2_value = (int) markers2.Data.GetValue(i, j, 0);
                        if (markers2_value == -1)
                        {
                            img.Data.SetValue((byte)255, i, j, 0);
                            img.Data.SetValue((byte)0, i, j, 1);
                            img.Data.SetValue((byte)0, i, j, 2);
                        }
                    }
                }
                CvInvoke.PutText(img, $"Znaleziono {counter} obiektow", new Point(20,20), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(0, 255, 0));
                ///////
                return Utils.EmguImgToBmp(img.Data);
            }
            
        }
        public static class Lab6
        {
            public static Bitmap FindContours(Bitmap bmp, out int contoursNum)
            {
                // Preprocessing
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr);
                Image<Gray, Byte> thresh = new Image<Gray, byte>(img.Size);

                // Thresholding
                CvInvoke.Threshold(img, thresh, 127, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                Mat hierarchy = new Mat(); 
                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                CvInvoke.FindContours(thresh, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                contoursNum = contours.Size;
                Image<Bgr, Byte> img2 = new Image<Bgr, byte>(img.Size);
                CvInvoke.CvtColor(thresh, img2, Emgu.CV.CvEnum.ColorConversion.Gray2Rgb);
                Random rnd = new Random();
                for (int i = 0; i < contoursNum; i++)
                {
                    Emgu.CV.Util.VectorOfPoint cnt = contours[i];
                    //CvInvoke.DrawContours(img2, cnt, 0, new MCvScalar());
                    img2.DrawPolyline(cnt.ToArray(), true, new Bgr(rnd.Next(50, 200), rnd.Next(50, 200), rnd.Next(50, 200)),3);
                }
                //CvInvoke.DrawContours(img2, contours[0], 0, new MCvScalar(255,0,0));

                return Utils.EmguImgToBmp(img2.Data);
            }
            public static Dictionary<string, double> FindFeatures(Bitmap bmp, int contourIndex)
            {
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> img = new Image<Gray, Byte>(bmpArr);
                Image<Gray, Byte> thresh = new Image<Gray, byte>(img.Size);

                // Thresholding
                CvInvoke.Threshold(img, thresh, 127, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                Mat hierarchy = new Mat();
                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                CvInvoke.FindContours(thresh, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                Emgu.CV.Util.VectorOfPoint cnt = contours[contourIndex];
                Moments moments = CvInvoke.Moments(cnt);
                
                // Area and perimeter 
                double area = CvInvoke.ContourArea(cnt);
                double perimeter = CvInvoke.ArcLength(cnt, true);

                // Shape factors 
                // Aspect ratio
                Rectangle rect = CvInvoke.BoundingRectangle(cnt);
                double aspect_ratio = ((double)rect.Width) / rect.Height;
                // Extent
                double extent = area / rect.Width * rect.Height;
                // solidity 
                Point[] points = cnt.ToArray();
                PointF[] pointFs = new PointF[points.Length];
                for (int i = 0; i < points.Length; ++i)
                {
                    Point point = points[i];
                    pointFs[i] = new PointF(point.X, point.Y);
                }
                PointF[] hull = CvInvoke.ConvexHull(pointFs);
                points = new Point[hull.Length];
                for (int i = 0; i < hull.Length; ++i)
                {
                    PointF point = hull[i];
                    points[i] = new Point((int)point.X, (int)point.Y);
                }
                Emgu.CV.Util.VectorOfPoint h = new Emgu.CV.Util.VectorOfPoint(points);
                double hull_area = CvInvoke.ContourArea(h,true);
                double solidity = ((double)area / hull_area);

                //Equivalent Diameter 
                double equivalent_diameter = Math.Sqrt(4 * area / Math.PI);
                Dictionary<string, double> featuresDict = new Dictionary<string, double>()
                {
                    {"M00", moments.M00 },
                    {"M01", moments.M01 },
                    {"M02", moments.M02 },
                    {"M03", moments.M03 },
                    {"M10", moments.M10 },
                    {"M11", moments.M11 },
                    {"M12", moments.M12 },
                    {"M20", moments.M20 },
                    {"M21", moments.M21 },
                    {"M30", moments.M30 },

                    {"Mu02", moments.Mu02 },
                    {"Mu03", moments.Mu03 },
                    {"Mu11", moments.Mu11 },
                    {"Mu12", moments.Mu12 },
                    {"Mu20", moments.Mu20 },
                    {"Mu21", moments.Mu21 },
                    {"Mu30", moments.Mu30 },

                    {"Nu02", moments.Nu02 },
                    {"Nu03", moments.Nu03 },
                    {"Nu11", moments.Nu11 },
                    {"Nu12", moments.Nu12 },
                    {"Nu20", moments.Nu20 },
                    {"Nu21", moments.Nu21 },
                    {"Nu30", moments.Nu30 },
                    
                    {"Area", area },
                    {"Perimeter", perimeter },

                    {"Aspect ratio", aspect_ratio },
                    {"Extent", extent },
                    {"Solidity", solidity },
                    {"Equivalent Diameter", equivalent_diameter },
                };
                return featuresDict;
            }
            
            public static Image<Gray,Byte>[] LoadImages(HashSet<string> filenames)
            {
                List<string> filenamesList = filenames.ToList();
                Image<Gray, Byte>[] imageArray = new Image<Gray, Byte>[filenames.Count];
                for (int i = 0; i < imageArray.Length; ++i)
                {
                    imageArray[i] = new Image<Gray, byte>(filenamesList[i]);
                }
                return imageArray;
            }
            public static double[][] GetFeat(Image<Gray, Byte> img)
            {
                Image<Gray, Byte> thresh = new Image<Gray, byte>(img.Size);
                CvInvoke.Threshold(img, thresh, 127, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                Mat hierarchy = new Mat();
                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                CvInvoke.FindContours(thresh, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                double[][] M_all = new double[contours.Size][];
                for (int i = 0; i < contours.Size; ++i)
                {
                    Emgu.CV.Util.VectorOfPoint cnt = contours[i];
                    Moments moments = CvInvoke.Moments(cnt);

                    double area = CvInvoke.ContourArea(cnt);
                    double perimeter = CvInvoke.ArcLength(cnt, true);
                    Rectangle rect = CvInvoke.BoundingRectangle(cnt);
                    double aspect_ratio = ((double)rect.Width) / rect.Height;
                    double rect_area = rect.Width * rect.Height;
                    double extent = ((double)area) * rect_area;
                    double equi_diameter = Math.Sqrt(4 * area / Math.PI);

                    double[] M_vec = new double[]
                    {
                        moments.M00, moments.M01, moments.M02, moments.M03, moments.M10, moments.M11, moments.M12, moments.M20, moments.M21, moments.M30,
                        moments.Mu02, moments.Mu03, moments.Mu11, moments.Mu12, moments.Mu20, moments.Mu21, moments.Mu30,
                        moments.Nu02, moments.Nu03, moments.Nu11, moments.Nu12, moments.Nu20, moments.Nu21, moments.Nu30,
                        area, perimeter, aspect_ratio, extent, equi_diameter
                    };
                    M_all[i] = M_vec;
                }
                return M_all;
            }
            
            public static int[] GetTarget(double[][] input_feats, int target_class = 1)
            {
                int[] Out = new int[input_feats.Length];
                for (int i = 0; i < Out.Length; ++i)
                    Out[i] = 1 * target_class;
                return Out;
            }
            public static Emgu.CV.ML.SVM Train(HashSet<string> filenames)
            {
                Image<Gray, Byte>[] imageArray = LoadImages(filenames);
                //dla każdego obiektu ze zbioru uczącego generujemy wektor cech
                double[][][] featArr = new double[imageArray.Length][][];
                int contourFeatsCounter = 0;
                int[] contourFeatsCntArr = new int[featArr.Length];
                for (int i = 0; i < imageArray.Length; i++)
                {
                    double[][] feat = GetFeat(imageArray[i]);
                    List<double[]> featList = feat.ToList();
                    featList.RemoveAt(feat.Length - 1);
                    feat = featList.ToArray();
                    featArr[i] = feat;
                    contourFeatsCounter += feat.Length;
                    contourFeatsCntArr[i] = feat.Length;
                }
                double[][] x_input = new double[contourFeatsCounter][];
                int shift = 0;
                for (int i = 0; i < featArr.Length; i++)
                {
                    featArr[i].CopyTo(x_input, shift);
                    shift += contourFeatsCntArr[i];
                }
                float[,] X_input = new float[x_input.Length, x_input[0].Length];
                for (int i = 0; i < X_input.GetLength(0); i++)
                {
                    for (int j = 0; j < X_input.GetLength(1); j++)
                    {
                        X_input[i, j] = (float) x_input[i][j];
                    }
                }
                // przygotowanie zbiorczego wektora etykiet
                shift = 0;
                int[] t_input = new int[contourFeatsCounter];
                for (int i = 0; i < featArr.Length; ++i)
                {
                    int[] t_vec = GetTarget(featArr[i], i + 1);
                    t_vec.CopyTo(t_input, shift);
                    shift += contourFeatsCntArr[i];
                }
                Emgu.CV.ML.SVM mySVM = new Emgu.CV.ML.SVM(); // Utworzenie SVM
                mySVM.Type = Emgu.CV.ML.SVM.SvmType.CSvc;
                mySVM.SetKernel(Emgu.CV.ML.SVM.SvmKernelType.Linear);
                mySVM.TermCriteria = new MCvTermCriteria(10000, 1e-6);
                Matrix<float> x_in = new Matrix<float>(X_input);
                Matrix<int> t_in = new Matrix<int>(t_input);
                TrainData trainData = new TrainData(x_in, DataLayoutType.RowSample, t_in);
                mySVM.Train(trainData);
                return mySVM;
            }
            public static Bitmap Predict(Emgu.CV.ML.SVM mySVM, Bitmap bmp, int kindsNum)
            {
                byte[,,] bmpArr = Utils.BmpToGraySArray(bmp);
                Image<Gray, Byte> test_img = new Image<Gray, byte>(bmpArr);
                double[][] feat_test = GetFeat(test_img);
                Image<Gray, Byte> thresh = new Image<Gray, byte>(test_img.Size);
                CvInvoke.Threshold(test_img, thresh, 127, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                Mat hierarchy = new Mat();

                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                CvInvoke.FindContours(thresh, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                Image<Bgr, Byte> img3 = new Image<Bgr, byte>(test_img.Size);
                CvInvoke.CvtColor(test_img, img3, Emgu.CV.CvEnum.ColorConversion.Gray2Bgr);

                List<string> colorsArr =
                    typeof(System.Drawing.Color)
                        .GetProperties()
                        .Where(x => x.PropertyType == typeof(System.Drawing.Color))
                        .Where(x => x.Name != "Black")
                        .Select(x => x.Name)
                        .ToList();
                Color[] colors = new Color[kindsNum];
                for (int i = 0; i < colors.Length; i++)
                {
                    Random rColor = new Random();
                    string colorName = colorsArr[rColor.Next(0, colorsArr.Count)];
                    colors[i] = Color.FromName(colorName);
                    colorsArr.Remove(colorName);
                }

                for (int x = 0; x < contours.Size; x++)
                {
                    float[,] tmp1 = new float[1, 29];
                    for (int i = 0; i < tmp1.Length; i++)
                    {
                        tmp1[0, i] = (float)feat_test[x][i];
                    }
                    Matrix<float> x_in = new Matrix<float>(tmp1);
                    Mat response = new Mat();
                    mySVM.Predict(x_in, response);
                    int resp = Convert.ToInt32(response.GetData().GetValue(0, 0));
                    Emgu.CV.Util.VectorOfPoint cnt = contours[x];
                    if (resp > 0 && resp <= colors.Length)
                        img3.DrawPolyline(cnt.ToArray(), true, new Bgr(colors[resp-1]), 3);
                    else
                        img3.DrawPolyline(cnt.ToArray(), true, new Bgr(Color.Black), 3);
                }
                return Utils.EmguImgToBmp(img3.Data);
            }
        }
    }
}
