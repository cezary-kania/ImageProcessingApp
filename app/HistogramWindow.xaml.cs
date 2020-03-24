using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
namespace APO_v1
{
    /// <summary>
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    
    public partial class HistogramWindow : Window
    {
        private delegate BitmapImage PlotMaker();
        private int histogramScaleX = 3;
        private double zoom = 1;
        private string histogramName;
        private Bitmap histogramBmp;
        private int histogramMaxValue;
        private Models.Image image;
        private ImageWindow parentWindow;
        private Dictionary<string, PlotMaker> histogramPlotMap;
        public HistogramWindow(Models.Image image, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.image = image;
            Title  = histogramName = string.Format("{0}_Histogram_{1}.bmp", image.TmpfileName.Split('.')[0], image.ColorFormat);
            ResizeMode = ResizeMode.CanMinimize;
            parentWindow.FindLUT();
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
            if(image.ColorFormat == Models.Image.EColorFormat.GrayScale)
                newhistogramPlotMap.Add("Grayscale", () => { return NewHistogramBitMap(image.LUT[0]); });
            else if (image.ColorFormat == Models.Image.EColorFormat.RGB)
            {
                newhistogramPlotMap.Add("Red", () => { return NewHistogramBitMap(image.LUT[0]); });
                newhistogramPlotMap.Add("Green", () => { return NewHistogramBitMap(image.LUT[1]); });
                newhistogramPlotMap.Add("Blue", () => { return NewHistogramBitMap(image.LUT[2]); });
                newhistogramPlotMap.Add("Cumulated", () => { return NewHistogramBitMap(image.LUT[3]); });
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
                histInfoLabel.Content = "Color: " + (int)(e.GetPosition(HistPlot).X + 1) / 3 + " Amount: " + image.LUT[colorIndex][(int)(e.GetPosition(HistPlot).X + 1) / 3]; 
            };
            LabelmaxValue.Content = (zoom == 1) ? histogramMaxValue + " - " : "";
            LabelminColor.Content = 0;
            LabelmaxColor.Content = image.LUT[0].Length - 1;
        }
        private BitmapImage NewHistogramBitMap(uint[] singleLUT)
        {
            int bmpWidth = (int) HistPlot.Width, bmpheight = (int) HistPlot.Height;
            uint max = 0;
            foreach (uint num in singleLUT)
                if (num > max) max = num;
            double Yscale;
            if (zoom == 1)
                Yscale = max / ((double)bmpheight - 50);
            else
                Yscale = (max / zoom) / ((double)bmpheight);
            histogramBmp = new Bitmap(bmpWidth, bmpheight);
            histogramMaxValue = (int) max;
            for (int i = 1; i < bmpWidth - 1; i++)
            {
                for (int j = 1; j < bmpheight - 1; j++)
                    histogramBmp.SetPixel(i, j, System.Drawing.Color.White);
            }
            for (int i = 0, z = 0; i < singleLUT.Length; i++)
            {
                for (int j = 0; j < singleLUT[i] / Yscale; ++j)
                    histogramBmp.SetPixel(z + i, Math.Max(bmpheight - j - 1, 0), System.Drawing.Color.Black);
                if(singleLUT[i] / Yscale < 10 && singleLUT[i] > 0)
                    histogramBmp.SetPixel(z + i, bmpheight - 2, System.Drawing.Color.Black);
                z += histogramScaleX - 1;
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
            image.HistStretching();
            image.HistStretching();
            MakePlot(colorPicker.SelectedItem.ToString());
            parentWindow.ReloadImage();
        }
        private void HistAlignmentBtn_Click(object sender, RoutedEventArgs e)
        {
            image.HistAligment();
            MakePlot(colorPicker.SelectedItem.ToString());
            parentWindow.ReloadImage();
        }
        private void colorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MakePlot(colorPicker.SelectedItem.ToString());
        }
        private void ZoomBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)e.Source;
            zoom = Convert.ToDouble(item.Header.ToString().Replace("%","").Replace("_", "")) / 100.0;
            foreach (MenuItem menuItem in zoomCtrl.Items) menuItem.IsChecked = false;
            item.IsChecked = true;
            MakePlot(colorPicker.SelectedItem.ToString());
        }
        public void ReloadHistogram()
        {
            MakePlot(colorPicker.SelectedItem.ToString());
        }
    }
}
