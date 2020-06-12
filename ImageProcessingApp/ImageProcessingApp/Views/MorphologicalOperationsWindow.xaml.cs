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
    /// Interaction logic for MorphologicalOperationsWindow.xaml
    /// </summary>
    public partial class MorphologicalOperationsWindow : Window
    {
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private int elementRadius;
        public MorphologicalOperationsWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            operationCB.Items.Add("Erosion");
            operationCB.Items.Add("Dilation");
            operationCB.Items.Add("Opening");
            operationCB.Items.Add("Closing");
            operationCB.SelectedIndex = 0;
            elementCB.Items.Add("diamond");
            elementCB.Items.Add("quad");
            elementCB.SelectedIndex = 0;
            BorderOpCB.Items.Add("replicate");
            BorderOpCB.Items.Add("reflect");
            BorderOpCB.Items.Add("isolated");
            BorderOpCB.SelectedIndex = 0;
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
            if(!Models.ImageOperations.MorphologicalOperations.CheckIfBinary(prev_image.Bitmap))
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
            switch (operationCB.SelectedItem.ToString())
            {
                case "Erosion":
                    prev_image.Bitmap = Models.ImageOperations.MorphologicalOperations.Erosion(prev_image.Bitmap, 
                                                                                               elementCB.SelectedItem.ToString(), 
                                                                                               elementRadius, 
                                                                                               BorderOpCB.SelectedItem.ToString());
                    break;
                case "Dilation":
                    prev_image.Bitmap = Models.ImageOperations.MorphologicalOperations.Dilation(prev_image.Bitmap,
                                                                                               elementCB.SelectedItem.ToString(),
                                                                                               elementRadius,
                                                                                               BorderOpCB.SelectedItem.ToString());
                    break;
                case "Opening":
                    prev_image.Bitmap = Models.ImageOperations.MorphologicalOperations.Opening(prev_image.Bitmap,
                                                                                               elementCB.SelectedItem.ToString(),
                                                                                               elementRadius,
                                                                                               BorderOpCB.SelectedItem.ToString());
                    break;
                case "Closing":
                    prev_image.Bitmap = Models.ImageOperations.MorphologicalOperations.Closing(prev_image.Bitmap,
                                                                                               elementCB.SelectedItem.ToString(),
                                                                                               elementRadius,
                                                                                               BorderOpCB.SelectedItem.ToString());
                    break;
                default:
                    break;
            }
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
        }
        private void radiusTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteBtn.IsEnabled = ApplyBtn.IsEnabled = int.TryParse(radiusTB.Text, out elementRadius) && elementRadius % 2 == 1 && elementRadius >= 3;
        }
    }
}
