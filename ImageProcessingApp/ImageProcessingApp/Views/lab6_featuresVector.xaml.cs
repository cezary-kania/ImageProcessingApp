using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for lab6_featuresVector.xaml
    /// </summary>
    public partial class lab6_featuresVector : Window
    {
        private ObservableCollection<Feature> featureList = new ObservableCollection<Feature>();
        private Models.Image img;
        private Models.Image prev_image;
        private int contoursNum;
        private class Feature
        {
            public string feature { get; set; }
            public double value { get; set; }
        }
        public lab6_featuresVector(Models.Image img)
        {
            InitializeComponent();
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);

            VFeatures.ItemsSource = featureList;
            prev_image.Bitmap = Models.ImageOperations.Lab6.FindContours(prev_image.Bitmap, out contoursNum);
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);

            for (int i = 0; i < contoursNum; ++i)
            {
                ContourCB.Items.Add($"Contour {i + 1}");
            }
            ContourCB.SelectedIndex = 0;
        }

        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindvBtn_Click(object sender, RoutedEventArgs e)
        {
            int contourIndex = ContourCB.SelectedIndex;
            FillFeatureList(contourIndex);
        }
        private void FillFeatureList(int contourIndex)
        {
            featureList.Clear();
            Dictionary<string, double> featuresDict = Models.ImageOperations.Lab6.FindFeatures(prev_image.Bitmap, contourIndex);
            foreach (KeyValuePair<string, double> feature in featuresDict)
            {
                featureList.Add(new Feature() { feature = feature.Key, value = feature.Value });
            }
        }
    }
}
