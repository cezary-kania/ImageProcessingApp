using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    public partial class HistogramWindow : Window
    {
        private delegate BitmapImage PlotMaker();
        private double zoom = 1;
        private string histogramName;
        private Bitmap histogramBmp;
        private int histogramMaxValue;
        private Models.Image image;
        private ImageWindow parentWindow;
        private int[][] LUT;
        private Dictionary<string, PlotMaker> histogramPlotMap;
        public HistogramWindow(Models.Image image, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.image = image;
            Title = histogramName = string.Format("{0}_Histogram_{1}.bmp", image.filename.Split('.')[0], image.ColorFormat);
            ResizeMode = ResizeMode.CanMinimize;
            LUT = image.FindLookUpTable();
            histogramPlotMap = MakeMap();
            LoadKeysToCB();
            colorPicker.SelectedIndex = 0;
            this.parentWindow = parentWindow;
        }
        private void LoadKeysToCB()
        {
            foreach (string key in histogramPlotMap.Keys) colorPicker.Items.Add(key);
        }
        private Dictionary<string, PlotMaker> MakeMap()
        {
            Dictionary<string, PlotMaker> newhistogramPlotMap = new Dictionary<string, PlotMaker>();
            if (image.ColorFormat == Models.Image.EColorFormat.GrayScale)
                newhistogramPlotMap.Add("Grayscale", () => { return NewHistogramBitMap(LUT[0]); });
            else if (image.ColorFormat == Models.Image.EColorFormat.RGB)
            {
                newhistogramPlotMap.Add("Red", () => { return NewHistogramBitMap(LUT[0]); });
                newhistogramPlotMap.Add("Green", () => { return NewHistogramBitMap(LUT[1]); });
                newhistogramPlotMap.Add("Blue", () => { return NewHistogramBitMap(LUT[2]); });
                newhistogramPlotMap.Add("Cumulated", () => { return NewHistogramBitMap(LUT[3]); });
            }
            return newhistogramPlotMap;
        }
        private void MakePlot(string color)
        {
            BitmapImage img = histogramPlotMap[color]();
            HistPlot.Source = img;
            HistPlot.MouseMove += (sender, e) =>
            {
                int colorIndex = colorPicker.SelectedIndex;
                histInfoLabel.Content = "Color: " + (int)(e.GetPosition(HistPlot).X + 1) / 3 + " Amount: " + LUT[colorIndex][(int)(e.GetPosition(HistPlot).X + 1) / 3];
            };
            LabelmaxValue.Content = (zoom == 1) ? histogramMaxValue + " - " : "";
            LabelminColor.Content = 0;
            LabelmaxColor.Content = LUT[0].Length - 1;
        }
        private BitmapImage NewHistogramBitMap(int[] singleLUT)
        {
            int bmpWidth = (int)HistPlot.Width, bmpheight = (int)HistPlot.Height;
            uint max = 0;
            foreach (uint num in singleLUT)
                if (num > max) max = num;
            double Yscale;
            if (zoom == 1)
                Yscale = max / ((double)bmpheight - 50);
            else
                Yscale = (max / zoom) / ((double)bmpheight);
            histogramBmp = new Bitmap(bmpWidth, bmpheight);
            histogramMaxValue = (int)max;
            for (int i = 0; i < bmpWidth; i++)
            {
                histogramBmp.SetPixel(i, 0, System.Drawing.Color.Blue);
                histogramBmp.SetPixel(i, bmpheight - 1, System.Drawing.Color.Blue);
            }
            for (int i = 0; i < bmpheight; i++)
            {
                histogramBmp.SetPixel(0, i, System.Drawing.Color.Blue);
                histogramBmp.SetPixel(bmpWidth - 1, i, System.Drawing.Color.Blue);
            }
            for (int i = 1; i < bmpWidth - 1; i++)
            {
                for (int j = 1; j < bmpheight - 1; j++)
                    histogramBmp.SetPixel(i, j, System.Drawing.Color.White);
            }
            for (int i = 0, z = 0; i < singleLUT.Length; i++)
            {
                for (int j = 0; j < singleLUT[i] / Yscale; ++j)
                    histogramBmp.SetPixel(z + i, Math.Max(bmpheight - j - 1, 0), System.Drawing.Color.Black);
                if (singleLUT[i] / Yscale < 10 && singleLUT[i] > 0)
                    histogramBmp.SetPixel(z + i, bmpheight - 2, System.Drawing.Color.Black);
                z += 2;
            }
            return Utils.BitmapToImageSource(histogramBmp);
        }
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bmp file (*.bmp)|*.bmp";
            saveFileDialog.FileName = histogramName;
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream stream =
                new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    histogramBmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void HistStretchingBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.HistogramOperations.Stretching(image);
            ReloadHistogram();
            parentWindow.ReloadImage();
        }
        private void HistAlignmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.HistogramOperations.HistAlignment(image);
            ReloadHistogram();
            parentWindow.ReloadImage();
        }
        private void colorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MakePlot(colorPicker.SelectedItem.ToString());
        }
        private void ZoomBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)e.Source;
            zoom = Convert.ToDouble(item.Header.ToString().Replace("%", "").Replace("_", "")) / 100.0;
            foreach (MenuItem menuItem in zoomCtrl.Items) menuItem.IsChecked = false;
            item.IsChecked = true;
            MakePlot(colorPicker.SelectedItem.ToString());
        }
        public void ReloadHistogram()
        {
            LUT = image.FindLookUpTable();
            MakePlot(colorPicker.SelectedItem.ToString());
        }
        private void HistEqualizationBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.HistogramOperations.Equalization(image);
            ReloadHistogram();
            parentWindow.ReloadImage();
        }
    }
}
