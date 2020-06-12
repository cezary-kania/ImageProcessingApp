using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageProcessingApp.Views
{
    /// <summary>
    /// Interaction logic for RangeStrWindow.xaml
    /// </summary>
    public partial class RangeStrWindow : Window
    {
        private Models.Image img;
        private Models.Image prev_image;
        ImageWindow imageWindow;
        private uint p1, p2, q3, q4;
        public RangeStrWindow(Models.Image img, ImageWindow imageWindow)
        {
            InitializeComponent();
            this.img = img;
            this.imageWindow = imageWindow;
            prev_image = new Models.Image();
            CloneOrginalImage();
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
            p1_TB.Text = (p1 = (uint) img.MinColorValue()).ToString();
            p2_TB.Text = (p2 = (uint)img.MaxColorValue()).ToString();
            q3_TB.Text = (q3 = 0).ToString();
            q4_TB.Text = (q4 = 255).ToString();
        }
        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            img.Bitmap = (Bitmap)prev_image.Bitmap.Clone();
            imageWindow.ReloadImage();
            Close();
        }

        private void p1_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(p1_TB.Text, out p1) && p1 < p2 && p1 <= 255;
        }

        private void StretchBtn_Click(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            Models.ImageOperations.RangeStretching(prev_image, p1, p2, q3, q4);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void p2_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(p2_TB.Text, out p2) && p1 < p2 && p2 <= 255;
        }

        private void q3_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(q3_TB.Text, out q3) && q3 < q4 && q3 <= 255;
        }

        private void q4_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(q4_TB.Text, out q4) && q3 < q4 && q4 <= 255;
        }
    }
}
