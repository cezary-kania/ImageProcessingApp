using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows;
namespace APO_v1
{
    class MyImage
    {
        public MyImage(BitmapImage bitmapImage)
        {
            ImageWindow newImageW = new ImageWindow();
            newImageW.Show();

            BitmapImage image = bitmapImage;
            newImageW.image.Source = image;

            int height = image.PixelHeight;
            int width = image.PixelWidth;

            newImageW.Width = width;
            newImageW.Height = height;

            int stride = width * 4;
            int size = height * stride;
            byte[] pixels = new byte[size];
            image.CopyPixels(pixels, stride, 0);

            int x = 0, y = 0;
            int index = y * stride + 4 * x;

            newImageW.Title = pixels[index] + " " + pixels[index + 1] + " " + pixels[index + 2] + " " + pixels[index + 3];
        }
    }
}
