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
    /// Interaction logic for EdetectionWindow.xaml
    /// </summary>
    public partial class EdetectionWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private int th1 = 0, th2 = 255;
        public EdetectionWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            maskCB.Items.Add("Sobel");
            maskCB.Items.Add("Laplacian");
            maskCB.Items.Add("Canny");
            maskCB.SelectedIndex = 0;
            BorderOpCB.Items.Add("replicate");
            BorderOpCB.Items.Add("reflect");
            BorderOpCB.Items.Add("isolated");
            BorderOpCB.SelectedIndex = 0;
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
            if (maskCB.SelectedItem.ToString().Equals("Sobel"))
                prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Sobel(prev_image.Bitmap, BorderOpCB.SelectedItem.ToString());
            else if(maskCB.SelectedItem.ToString().Equals("Laplacian"))
                prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Laplacian(prev_image.Bitmap, BorderOpCB.SelectedItem.ToString());
            else
                prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Canny(prev_image.Bitmap, th1, th2);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void th1TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteBtn.IsEnabled = int.TryParse(th1TB.Text, out th1) && th1 >= 0 && th1 <= 255 && th1 < th2;
        }

        private void maskCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (maskCB.SelectedItem.ToString().Equals("Canny"))
                th1TB.IsEnabled = th2TB.IsEnabled = th1_l.IsEnabled = th2_l.IsEnabled = true;
            else
                th1TB.IsEnabled = th2TB.IsEnabled = th1_l.IsEnabled = th2_l.IsEnabled = false;
        }

        private void th2TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteBtn.IsEnabled = int.TryParse(th2TB.Text, out th2) && th2 >= 0 && th2 <= 255 && th1 < th2;
        }
    }
}
