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
    /// Interaction logic for LinearSharpenWindow.xaml
    /// </summary>
    public partial class LinearSharpenWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private Dictionary<string, float[,]> masks = new Dictionary<string, float[,]>()
        {
            { "Mask 1", new float[,]{{0,-1,0 },{ -1, 4, -1 },{0,-1,0}} },
            { "Mask 2", new float[,]{{ -1, -1, -1 },{ -1, 8, -1 },{ -1, -1, -1 } } },
            { "Mask 3", new float[,]{{ 1, -2, 1 },{ -2, 4, -2 },{ 1, -2, 1 } } },
        };
        public LinearSharpenWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            foreach (string key in masks.Keys) maskCB.Items.Add(key);
            maskCB.SelectedIndex = 0;
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
            string maskKey = maskCB.SelectedItem.ToString();
            prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Filter2D(prev_image.Bitmap, masks[maskKey], BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void ReloadMask()
        {
            string maskKey = maskCB.SelectedItem.ToString();
            m0.Text = masks[maskKey][0, 0].ToString();
            m1.Text = masks[maskKey][0, 1].ToString();
            m2.Text = masks[maskKey][0, 2].ToString();
            m3.Text = masks[maskKey][1, 0].ToString();
            m4.Text = masks[maskKey][1, 1].ToString();
            m5.Text = masks[maskKey][1, 2].ToString();
            m6.Text = masks[maskKey][2, 0].ToString();
            m7.Text = masks[maskKey][2, 1].ToString();
            m8.Text = masks[maskKey][2, 2].ToString();
        }
        private void maskCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadMask();
        }
    }
}
