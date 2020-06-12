using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ObjectSegmentationWindow.xaml
    /// </summary>
    public partial class ObjectSegmentationWindow2 : Window
    {
        private Models.Image img, prev_image;
        private int lowerR, lowerG, lowerB,
                    upperR, upperG, upperB,
                    objCounter = 0;
        ImageWindow parentWindow;
        private Models.Image.EColorFormat imageFormat; 
        private bool windowLoading = true;
        public ObjectSegmentationWindow2(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.img = img;
            this.parentWindow = parentWindow;
            prev_image = new Models.Image();
            CloneOrginalImage();
            lowerR = lowerG = lowerB = 0;
            upperR = upperG = upperB = 255;
            imageFormat = img.ColorFormat;
            AdjustLayout();
            windowLoading = false;
        }
        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            img.Bitmap = (Bitmap) prev_image.Bitmap.Clone();
            parentWindow.ReloadImage();
            Close();
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            if(imageFormat == Models.Image.EColorFormat.RGB)
            {
                prev_image.Bitmap = Models.ImageOperations.SegmentAndCountObjs(prev_image.Bitmap, out objCounter,
                                                                           new int[] { lowerR, lowerG, lowerB },
                                                                           new int[] { upperR, upperG, upperB });
            }
            else
            {
                prev_image.Bitmap = Models.ImageOperations.SegmentAndCountObjs(prev_image.Bitmap, out objCounter,
                                                                          new int[] { lowerR, lowerR, lowerR },
                                                                          new int[] { upperR, upperR, upperR });
            }
            objsCounterLB.Content = $"Objects counted:{objCounter}";
            objsCounterLB.Visibility = Visibility.Visible;
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void SaveToFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.SaveFileAs(prev_image.Bitmap, img.filename);
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void colorTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!windowLoading) ValidateInputs();
        }
        private void AdjustLayout()
        {
            lowerRTB.Text = lowerG.ToString();
            upperRTB.Text = upperR.ToString();
            lowerBTB.Text = lowerB.ToString();
            lowerGTB.Text = lowerR.ToString();
            upperGTB.Text = upperG.ToString();
            upperBTB.Text = upperB.ToString();
            if (imageFormat == Models.Image.EColorFormat.GrayScale)
            {
                lowerBTB.Visibility = Visibility.Hidden;
                lowerGTB.Visibility = Visibility.Hidden;
                upperGTB.Visibility = Visibility.Hidden;
                upperBTB.Visibility = Visibility.Hidden;
                upperG_label.Visibility = Visibility.Hidden;
                upperB_label.Visibility = Visibility.Hidden;
                lowerG_label.Visibility = Visibility.Hidden;
                lowerB_label.Visibility = Visibility.Hidden;
                upperR_label.Content = "G";
                lowerR_label.Content = "G";
            }
        }
        private void ValidateInputs()
        {
            ApplyBtn.IsEnabled = int.TryParse(lowerRTB.Text, out lowerR) && int.TryParse(upperRTB.Text, out upperR)
                                   && lowerR >= 0 && lowerR <= 255 && upperR >= 0 && upperR <= 255 && lowerR < upperR
                                 &&
                                 int.TryParse(lowerGTB.Text, out lowerG) && int.TryParse(upperGTB.Text, out upperG)
                                   && lowerG >= 0 && lowerG <= 255 && upperG >= 0 && upperG <= 255 && lowerG < upperG
                                 &&
                                 int.TryParse(lowerBTB.Text, out lowerB) && int.TryParse(upperBTB.Text, out upperB)
                                   && lowerB >= 0 && lowerB <= 255 && upperB >= 0 && upperB <= 255 && lowerB < upperB;
        }
    }
}
