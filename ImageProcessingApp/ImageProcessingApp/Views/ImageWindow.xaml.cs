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
        private MainWindow mainWindow;
        private HistogramWindow histogramWindow;
        private Models.Image img;
        private Models.Application app;
        private List<Window> subWindows = new List<Window>();
        public ImageWindow(MainWindow mainWindow, Models.Image img, Models.Application app)
        {
            InitializeComponent();
            this.img = img;
            this.app = app;
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
            if (histogramWindow != null)
                histogramWindow.ReloadHistogram();
        }
        private void HistogramBtnClick(object sender, RoutedEventArgs e)
        {
            MakeHistogram();
        }
        private void NegationBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.ImageNegation(img);
            ReloadImage();
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
        private void BluringBtn_Click(object sender, RoutedEventArgs e)
        {
            new BluringWindow(img, this).ShowDialog();
        }
        private void EdetectionBtn_Click(object sender, RoutedEventArgs e)
        {
            new EdetectionWindow(img, this).ShowDialog();
        }
        private void LSharpeningMI__Click(object sender, RoutedEventArgs e)
        {
            new LinearSharpenWindow(img, this).ShowDialog();
        }

        private void PrewittEDetectionMI_Click(object sender, RoutedEventArgs e)
        {
            new PrewittWindow(img, this).ShowDialog();
        }

        private void CustomMaskMI_Click(object sender, RoutedEventArgs e)
        {
            new CustomMaskWindow(img, this).ShowDialog();
        }

        private void MedianBlurMI_Click(object sender, RoutedEventArgs e)
        {
            new MedianBlurWindow(img, this).ShowDialog();
        }

        private void ObjsSeg_Click(object sender, RoutedEventArgs e)
        {
            new ObjectSegmentationWindow2(img, this).ShowDialog();
        }

        private void MorphologicalOP_Click(object sender, RoutedEventArgs e)
        {
            new MorphologicalOperationsWindow(img, this).ShowDialog();
        }

        private void MaskConvolutionMI_Click(object sender, RoutedEventArgs e)
        {
            new MaskConvolutionWindow(img, this).ShowDialog();
        }

        private void Skeletonization_Click(object sender, RoutedEventArgs e)
        {
            new SkeletonizationWindow(img, this).ShowDialog();
        }

        private void Lab5_th_Click(object sender, RoutedEventArgs e)
        {
            new Lab5_thresholding(img, this).ShowDialog();
        }
        private void DuplicateBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.Image duplicatedImg = new Models.Image();
            string current_imgname = (string) img.filename.Clone();
            duplicatedImg.filename = app.RenderNewTmpName(ref current_imgname);
            duplicatedImg.Bitmap = (System.Drawing.Bitmap) img.Bitmap.Clone();
            app.images.Add(duplicatedImg.filename, duplicatedImg);
            ImageWindow imageWindow = new ImageWindow(mainWindow, duplicatedImg, app);
            mainWindow.imageWindows.Add(duplicatedImg.filename, imageWindow);
            imageWindow.Owner = Window.GetWindow(mainWindow);
            mainWindow.AddImageToMenus(duplicatedImg.filename);
            imageWindow.Show();
        }

        private void FVector_Click(object sender, RoutedEventArgs e)
        {
            new lab6_featuresVector(img).ShowDialog();
        }
    }
}
