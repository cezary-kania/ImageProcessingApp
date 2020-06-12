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
    /// Interaction logic for SkeletonizationWindow.xaml
    /// </summary>
    public partial class SkeletonizationWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        public SkeletonizationWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            BorderOpCB.Items.Add("replicate");
            BorderOpCB.Items.Add("reflect");
            BorderOpCB.Items.Add("isolated");
            BorderOpCB.SelectedIndex = 0;
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
            if (!Models.ImageOperations.MorphologicalOperations.CheckIfBinary(prev_image.Bitmap))
            {
                ExecuteBtn.IsEnabled = false;
                ApplyBtn.IsEnabled = false;
                notBinaryLB.Visibility = Visibility.Visible;
            }
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
            prev_image.Bitmap = Models.ImageOperations.MorphologicalOperations.Skeletonization(prev_image.Bitmap, BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
    }
}
