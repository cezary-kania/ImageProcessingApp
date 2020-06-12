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
    /// Interaction logic for MedianBlurWindow.xaml
    /// </summary>
    public partial class MedianBlurWindow : Window
    {
        public MedianBlurWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            bluringCB.Items.Add("3x3");
            bluringCB.Items.Add("5x5");
            bluringCB.Items.Add("7x7");
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
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
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
            int ksize = Convert.ToInt32(bluringCB.SelectedItem.ToString().Substring(0, 1));
            prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.MedianBlur(prev_image.Bitmap,ksize,BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
    }
}
