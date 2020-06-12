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
    /// Interaction logic for Lab5_thresholding.xaml
    /// </summary>
    public partial class Lab5_thresholding : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private int threshold = 128;
        public Lab5_thresholding(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            string[] thMethods = new string[] { "Interactive", "Adaptive", "Otsu", "Watershed" };
            ThMethodComboBox.ItemsSource = thMethods;
            ThMethodComboBox.SelectedIndex = 0;
            ThresholdTB.Text = threshold.ToString();
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
        }
        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            img.Bitmap = (Bitmap)prev_image.Bitmap.Clone();
            parentWindow.ReloadImage();
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExecuteBtn_Click(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            string selectedMethod = ThMethodComboBox.SelectedItem.ToString();
            switch (selectedMethod)
            {
                case "Interactive":
                    prev_image.Bitmap = Models.ImageOperations.Lab5_th.InteractiveThresholding(prev_image.Bitmap, threshold);
                    break;
                case "Adaptive":
                    prev_image.Bitmap = Models.ImageOperations.Lab5_th.AdaptiveThresholding(prev_image.Bitmap);
                    break;
                case "Otsu":
                    prev_image.Bitmap = Models.ImageOperations.Lab5_th.OtsuThresholding(prev_image.Bitmap);
                    break;
                case "Watershed":
                    prev_image.Bitmap = Models.ImageOperations.Lab5_th.WatershedThresholding(prev_image.Bitmap);
                    break;
                default:
                    break;
            }
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }

        private void ThresholdTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteBtn.IsEnabled = int.TryParse(ThresholdTB.Text, out threshold) && threshold >= 0 && threshold <= 255;
        }

        private void ThMethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ThresholdTB.IsEnabled = ThMethodComboBox.SelectedItem.ToString().Equals("Interactive");
        }
    }
}
