using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace APO_v1
{
    /// <summary>
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    
    public partial class HistogramWindow : Window
    {

        private uint[][] LUT;
        private string histogramName;
        private EColorFormat colorFormat;
        public HistogramWindow(string tmpFileName, BitmapImage bitmap)
        {
            InitializeComponent();
            colorFormat = CheckImgColorFormat(bitmap);
            histogramName = string.Format("{0}_Histogram_{1}", tmpFileName, colorFormat);
            Title = histogramName;
            MakeLUT(bitmap);
            foreach (var colorT in LUT)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < colorT.Length; i++)
                {
                    sb.Append(string.Format("{0}:{1} ",i,colorT[i]));
                }
                textBox.AppendText(sb.ToString() + Environment.NewLine);
            }
            
        }
        enum EColorFormat
        {
            GrayScale,
            RGB
        }
        private void MakeLUT(BitmapImage bitmap)
        {
            if (colorFormat == EColorFormat.GrayScale) LUT = new uint[1][];
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
        private byte[] GetPixels(BitmapImage bitmap)
        {
            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmap.CopyPixels(pixels, stride, 0);
            return pixels;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
