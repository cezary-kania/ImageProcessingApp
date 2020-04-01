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
    /// Interaction logic for PosterizeWindow.xaml
    /// </summary>
    public partial class PosterizeWindow : Window
    {
        private Models.Image img;
        private Models.Image prev_image;
        private ImageWindow parentWindow;
        private uint levels;
        public PosterizeWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.img = img;
            this.parentWindow = parentWindow;
            prev_image = new Models.Image();
            CloneOrginalImage();
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
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

        private void PostrerizeBtn_Click(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            Models.ImageOperations.Posterize(prev_image, (int)levels);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }

        private void LevelsTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            PosterizeBtn.IsEnabled = uint.TryParse(LevelsTB.Text, out levels) && levels > 0 && levels <= 256;
        }
    }
}
