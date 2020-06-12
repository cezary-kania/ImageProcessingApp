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
    /// Interaction logic for BluringWindow.xaml
    /// </summary>
    public partial class BluringWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        public BluringWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            bluringCB.Items.Add("Blur");
            bluringCB.Items.Add("Gaussian Blur");
            bluringCB.SelectedIndex = 0;
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
            if(bluringCB.SelectedItem.ToString().Equals("Blur"))
                prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Blur(prev_image.Bitmap, BorderOpCB.SelectedItem.ToString());
            else
                prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.GaussianBlur(prev_image.Bitmap, BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
    }
}
