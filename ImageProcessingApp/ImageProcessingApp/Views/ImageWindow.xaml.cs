using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        MainWindow mainWindow;
        HistogramWindow histogramWindow;
        Models.Image img;
        private List<Window> subWindows = new List<Window>();
        public ImageWindow(MainWindow mainWindow, Models.Image img)
        {
            InitializeComponent();
            this.img = img;
            this.mainWindow = mainWindow;
            Title = img.filename;
            imageControl.Source = Utils.BitmapToImageSource(img.Bitmap);
            Height = Width * img.Height / img.Width + 45;
            Show();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in subWindows) window.Close();
            mainWindow.CloseImageWindow(img.filename);
        }
        public void Save()
        {
            if (File.Exists(img.filename))
                Utils.SaveFile(img.Bitmap, img.filename);
            else
                Utils.SaveFileAs(img.Bitmap, img.filename);
        }
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.SaveFileAs(img.Bitmap, img.filename);
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void MakeHistogram()
        {
            histogramWindow = new HistogramWindow(img, this);
            subWindows.Add(histogramWindow);
            histogramWindow.Show();
        }
        public void ReloadImage()
        {
            imageControl.Source = Utils.BitmapToImageSource(img.Bitmap);
        }
        private void HistogramBtnClick(object sender, RoutedEventArgs e)
        {
            MakeHistogram();
        }
        private void NegationBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.ImageNegation(img);
            ReloadImage();
            if (histogramWindow != null)
                histogramWindow.ReloadHistogram();
        }
        private void ThresholdingBtn_Click(object sender, RoutedEventArgs e)
        {
            new ThresholdingWindow(img, this).ShowDialog();
        }
        private void PosterizeBtn_Click(object sender, RoutedEventArgs e)
        {
            new PosterizeWindow(img, this).ShowDialog();
        }
        private void LumRangeStr_Click(object sender, RoutedEventArgs e)
        {
            new RangeStrWindow(img, this).ShowDialog();
        }
    }
}
