using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace ImageProcessingApp.Models
{
    public class Image
    {
        public enum EColorFormat {GrayScale,RGB}
        public EColorFormat ColorFormat { get; private set; }
        public int colorsNum;
        public int Width { get { return Bitmap.Width; } }
        public int Height { get { return Bitmap.Height; } }
        public string filename { get; set; }
        private Bitmap bmp;
        public Image(Bitmap bmp, string filename)
        {
            this.bmp = bmp;
            this.filename = filename;
            ColorFormat = CheckImgColorFormat();
        }
        public Image() {}
        public Bitmap Bitmap
        {
            get { return bmp; }
            set
            {
                bmp = value;
                ColorFormat = CheckImgColorFormat();
            }
        }
        private EColorFormat CheckImgColorFormat()
        {
            for (int x = 0; x < Bitmap.Width; ++x)
            {
                for (int y = 0; y < Bitmap.Height; ++y)
                {
                    Color color = Bitmap.GetPixel(x,y);
                    if (!(color.R == color.G && color.R == color.G))
                    {
                        colorsNum = 3;
                        return EColorFormat.RGB;
                    }
                }
            }
            colorsNum = 1;
            return EColorFormat.GrayScale;
        }
        public int[][] FindLookUpTable()
        {
            int[][] LUT;
            if (ColorFormat == EColorFormat.GrayScale)
                LUT = new int[][] { new int[256] };
            else
                LUT = new int[][] { new int[256], new int[256], new int[256], new int[256], };
            for (int i = 0; i == 0 || (i < LUT.Length - 1); i++)
            {
                for (int x = 0; x < Bitmap.Width; ++x)
                {
                    for (int y = 0; y < Bitmap.Height; ++y)
                    {
                        Color color = Bitmap.GetPixel(x, y);
                        int[] colors = new int[] { color.R, color.G, color.B };
                        ++LUT[i][colors[i]];
                    }
                }
            }
            if (ColorFormat == EColorFormat.RGB)
            {
                LUT[3] = new int[LUT[0].Length];
                for (int i = 0; i < LUT[3].Length; i++)
                    LUT[3][i] = LUT[0][i] + LUT[1][i] + LUT[2][i];
            }
            return LUT;
        }
    }
}
