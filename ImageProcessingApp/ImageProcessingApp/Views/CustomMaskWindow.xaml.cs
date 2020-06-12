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
    /// Interaction logic for CustomMaskWindow.xaml
    /// </summary>
    public partial class CustomMaskWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private float[,] mask = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
        public CustomMaskWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            BorderOpCB.Items.Add("replicate");
            BorderOpCB.Items.Add("reflect");
            BorderOpCB.Items.Add("isolated");
            BorderOpCB.SelectedIndex = 0;
            ReloadMask();
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
        }
        private void mCell_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox s = (TextBox)sender;
            int cellNum = Convert.ToInt32(s.Name.Substring(1));
            int x = cellNum / 3, y = cellNum % 3;
            ExecuteBtn.IsEnabled = float.TryParse(s.Text, out mask[x, y]);
            ReloadMask();
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
            prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Filter2D(prev_image.Bitmap, mask, BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void ReloadMask()
        {
            m0.Text = mask[0, 0].ToString();
            m1.Text = mask[0, 1].ToString();
            m2.Text = mask[0, 2].ToString();
            m3.Text = mask[1, 0].ToString();
            m4.Text = mask[1, 1].ToString();
            m5.Text = mask[1, 2].ToString();
            m6.Text = mask[2, 0].ToString();
            m7.Text = mask[2, 1].ToString();
            m8.Text = mask[2, 2].ToString();
        }
    }
}
