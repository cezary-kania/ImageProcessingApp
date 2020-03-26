using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace APO_v1.Models
{
    class TwoArgsOperations
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
                    bmp.SetPixel(i, j, Color.FromArgb(R,G,B));
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
                    bmp.SetPixel(i, j, Color.FromArgb(unchecked((byte)~R), unchecked((byte)~G), unchecked((byte)~B)));
                }
            }
            return bmp;
        }
    }
}
