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
        private int histogramScaleX;
        private Bitmap histogramBmp;
        private Models.Image image;
        private ImageWindow parentWindow;
        public HistogramWindow(Models.Image image, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.image = image;
            Title  = string.Format("{0}_Histogram_{1}", image.TmpfileName, image.ColorFormat);
            ResizeMode = ResizeMode.CanMinimize;
            histogramPlotMap = MakeMap();
            LoadKeysToCB();
            colorPicker.SelectedIndex = 0;
            this.parentWindow = parentWindow;
        }
        private void LoadKeysToCB()
        {
            foreach (string key in histogramPlotMap.Keys) colorPicker.Items.Add(key);
        }
        private Dictionary<string, PlotMaker> histogramPlotMap;
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
            }
            return newhistogramPlotMap;
        }
        private void MakePlot(string color)
        {
            BitmapImage img = histogramPlotMap[color]();
            HistPlot.Source = img;
            HistPlot.MouseMove += (sender, e) =>
            { histInfoLabel.Content = "Color: " + (int)(e.GetPosition(HistPlot).X) / 3 + " Amount: " + image.LUT[0][(int)(e.GetPosition(HistPlot).X) / 3]; };
            Height = img.PixelHeight + 50;
        }
        private BitmapImage NewHistogramBitMap(uint[] singleLUT)
        {
            uint max = 0;
            histogramScaleX = 2;
            int bmpWidth = singleLUT.Length* (histogramScaleX + 1), bmpheight = 700;
            foreach (uint num in singleLUT)
                if (num > max) max = num;
            double scale = max / ((double)bmpheight - 20);
            histogramBmp = new Bitmap(bmpWidth, bmpheight);
            histogramBmp.SetResolution(100, 100);
            for (int i = 1; i < bmpWidth - 1; i++)
            {
                for (int j = 1; j < bmpheight - 1; j++)
                    histogramBmp.SetPixel(i,j, System.Drawing.Color.White);
            }
            for (int i = 0, z = 0; i < singleLUT.Length; i++)
            {
                    for (int j = 0; j < singleLUT[i] / scale; ++j)
                        histogramBmp.SetPixel(z + i, bmpheight - j - 1, System.Drawing.Color.Black);
                z += histogramScaleX;
            }
            return Utils.BitmapToImageSource(histogramBmp);
        }
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bmp file (*.bmp)|*.bmp";
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
            MakePlot(colorPicker.SelectedItem.ToString());
            parentWindow.ReloadImage();
        }
        private void HistAlignmentBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < image.LUT.Length; i++)
                image.LUT[i] = Models.HistogramOperations.LUTAlignment(image.LUT[i]);
            image.ReloadBitmap();
            MakePlot(colorPicker.SelectedItem.ToString());
            parentWindow.ReloadImage();
        }
        private void colorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MakePlot(colorPicker.SelectedItem.ToString());
        }
    }
}
