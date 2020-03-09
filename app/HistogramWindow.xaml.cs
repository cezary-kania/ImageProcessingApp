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
using System.IO;
using Microsoft.Win32;

namespace APO_v1
{
    /// <summary>
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    
    public partial class HistogramWindow : Window
    {

        private uint[][] LUT;
        private string histogramName;
        private int histogramScaleX;
        private EColorFormat colorFormat;
        private Bitmap bmp;
        public HistogramWindow(string tmpFileName, BitmapImage bitmap)
        {
            InitializeComponent();
            colorFormat = CheckImgColorFormat(bitmap);
            histogramName = string.Format("{0}_Histogram_{1}", tmpFileName, colorFormat);
            Title = histogramName;
            MakeLUT(bitmap);
            /*foreach (var colorT in LUT)
            {
                this.Grid.Children.Add(NewHistogramBitMap(colorT));
            }*/
            System.Windows.Controls.Image img = NewHistogramBitMap(LUT[0]);
            Title = img.Width.ToString();
            img.MouseMove += (sender, e) =>
            {
                Title = "Color: " + (int)(e.GetPosition(img).X) / 3 + " Amount: " + LUT[0][(int)(e.GetPosition(img).X) / 3];
            };
            Height += img.Height;
            Width = img.Width;
            this.Grid.Children.Add(img);
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
        private System.Windows.Controls.Image NewHistogramBitMap(uint[] singleLUT)
        {
            uint max = 0;
            histogramScaleX = 2;
            int bmpWidth = singleLUT.Length* (histogramScaleX + 1), bmpheight = 700;
            foreach (uint num in singleLUT)
                if (num > max) max = num;
            double scale = max / ((double)bmpheight - 20);
            int scaleX = bmpWidth / 256; 
            bmp = new Bitmap(bmpWidth, bmpheight);
            bmp.SetResolution(100, 100);
            for (int i = 0; i < bmpWidth; i++)
            {
                for (int j = 0; j < bmpheight; j++)
                {
                    bmp.SetPixel(i,j, System.Drawing.Color.White);
                }
            }
            for (int i = 0, z = 0; i < singleLUT.Length; i++)
            {
                    for (int j = 0; j < singleLUT[i] / scale; ++j)
                    {
                        bmp.SetPixel(z + i, bmpheight - j - 1, System.Drawing.Color.Black);
                    }
                z += histogramScaleX;
            }
            
            System.Windows.Controls.Image histogram = new System.Windows.Controls.Image();
            BitmapImage bitmapImage = BitmapToImageSource(bmp);
            Title = bitmapImage.PixelWidth.ToString();
            histogram.Source = BitmapToImageSource(bmp);
            histogram.Margin = new Thickness(0,20,0,0);
            histogram.Width = bitmapImage.PixelWidth;
            histogram.Height = bitmapImage.PixelHeight;

            return histogram;
        }
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
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

        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
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
    }
}
