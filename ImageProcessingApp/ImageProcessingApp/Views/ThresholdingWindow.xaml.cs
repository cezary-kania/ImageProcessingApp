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
    /// Interaction logic for ThresholdingWindow.xaml
    /// </summary>
    public partial class ThresholdingWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        public ThresholdingWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
            
            p1_slider.Maximum = 255;
            p1_slider.Minimum = 0;
            p1_TB.Text = (255 / 2).ToString();
            p1_slider.Value = 255 / 2;
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            img.Bitmap = (Bitmap) prev_image.Bitmap.Clone();
            parentWindow.ReloadImage();
            Close();
        }
        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void CB_2_Checked(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            Models.ImageOperations.OnePBinaryThresholingWithKeepingL(prev_image, (int)p1_slider.Value);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void CB_2_Unchecked(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            Models.ImageOperations.OnePBinaryThresholing(prev_image, (int)p1_slider.Value);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void p1_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newValue = (int)((Slider)sender).Value;
            p1_TB.Text = newValue.ToString();
            CloneOrginalImage();
            if (!(bool)CB_2.IsChecked)
                Models.ImageOperations.OnePBinaryThresholing(prev_image, newValue);
            else
                Models.ImageOperations.OnePBinaryThresholingWithKeepingL(prev_image, newValue);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //parentWindow.RestoreCopyIfExist();
        }
        private void p1_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            byte newP1;
            if (!byte.TryParse(((TextBox)sender).Text, out newP1))
            {
                p1_slider.IsEnabled = !p1_slider.IsEnabled;
                ApplyBtn.IsEnabled = !ApplyBtn.IsEnabled;
                return;
            };
            p1_slider.IsEnabled = true;
            ApplyBtn.IsEnabled = true;
            p1_slider.Value = newP1;
            CloneOrginalImage();
            if (!(bool)CB_2.IsChecked)
                Models.ImageOperations.OnePBinaryThresholing(prev_image, newP1);
            else
                Models.ImageOperations.OnePBinaryThresholingWithKeepingL(prev_image, newP1);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
