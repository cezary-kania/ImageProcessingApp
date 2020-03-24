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
namespace APO_v1
{
    /// <summary>
    /// Logika interakcji dla klasy ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private MainWindow mainWindow;
        private HistogramWindow histogramWindow;
        private List<Window> subWindows = new List<Window>();
        public string orginalFileName { get; private set; }
        public string tmpfileName { get; private set; }
        private Models.Image img;
        public ImageWindow(string orginalFileName, string tmpfileName, MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.orginalFileName = orginalFileName;
            this.tmpfileName = tmpfileName;
            img = new Models.Image(orginalFileName,tmpfileName);
            Title = this.tmpfileName;
            imageControl.Source = img.bitmapImg;
            Height = Width * img.Height / img.Width + 45;
            Show();
        }
        public void MakeHistogram()
        {
            histogramWindow = new HistogramWindow(img,this);
            subWindows.Add(histogramWindow);
            histogramWindow.Show();
        }
        private void HistogramBtnClick(object sender, RoutedEventArgs e)
        {
            MakeHistogram();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAllWindows();
            mainWindow.RemoveImgWindow(tmpfileName);
        }
        private void CloseAllWindows()
        {
            foreach (Window window in subWindows) window.Close();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWindows();
            Close();
        }
        public void Save()
        {
            if(File.Exists(tmpfileName))
                Utils.SaveFile(img.bitmapImg, tmpfileName);
            else
                Utils.SaveFileAs(img.bitmapImg, tmpfileName);
        }
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.SaveFileAs(img.bitmapImg, tmpfileName);
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.SaveFile(img.bitmapImg, tmpfileName);
        }
        public void ReloadImage()
        {
            imageControl.Source = img.bitmapImg;
        }
        private void NegationBtn_Click(object sender, RoutedEventArgs e)
        {
            img.ImageNegation();
            ReloadImage();
            if(histogramWindow != null)
                histogramWindow.ReloadHistogram();
        }
        private void ThresholdingBtn_Click(object sender, RoutedEventArgs e)
        {
            ThresholdingWindow thWindow = new ThresholdingWindow(this);
            subWindows.Add(thWindow);
            thWindow.Show();
        }
        public int GetMaximumLuminance()
        {
            return img.LUT[0].Length - 1;
        }
        public void ApplyBitmapChange()
        {
            img.imgCopy = null;
        }
        public void RestoreCopyIfExist()
        {
            img.RestoreCopyIfExists();
        }
        public void OnePBinaryThresholing(int p1)
        {
            img.OnePBinaryThresholing(p1);
            ReloadImage();
        }
        public void OnePBinaryThresholingWithKeepingL(int p1)
        {
            img.OnePBinaryThresholingWithKeepingL(p1);
            ReloadImage();
        }
        public void TwoPBinaryThresholing(int p1, int p2)
        {
            img.TwoPBinaryThresholing(p1, p2);
            ReloadImage();
        }
        public void TwoPBinaryThresholingWithKeepingL(int p1, int p2)
        {
            img.TwoPBinaryThresholingWithKeepingL(p1, p2);
            ReloadImage();
        }    
        public void FindLUT()
        {
            img.FindLUT();
        }
        private void LumLvlRed(object sender, RoutedEventArgs e)
        {

            LuminanceLvlRedWindow redWindow = new LuminanceLvlRedWindow(img, this);
            subWindows.Add(redWindow);
            redWindow.Show();
        }

        private void LuminanceRangeStr_Click(object sender, RoutedEventArgs e)
        {
            LumRangeStrWindow strWindow = new LumRangeStrWindow(img, this);
            subWindows.Add(strWindow);
            strWindow.Show();
        }
    }
}
