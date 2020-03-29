using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
            public static Bitmap Blending(Bitmap bmp1, Bitmap bmp2)
            {
                return null;
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
                    ColorRedirect[i][j] = level;
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
    }
}
