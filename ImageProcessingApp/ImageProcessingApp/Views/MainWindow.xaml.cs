using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageProcessingApp.Views;
namespace ImageProcessingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.Application app;
        public Dictionary<string, ImageWindow> imageWindows { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            app = new Models.Application();
            imageWindows = new Dictionary<string, ImageWindow>();
        }
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                if(app.AddNewImage(ref filename))
                {
                    ImageMI.IsEnabled = true;
                    PointOperations.IsEnabled = true;
                    SaveBtn.IsEnabled = true;
                    ImageWindow imageWindow = new ImageWindow(this, app.GetImage(filename));
                    imageWindow.Owner = Window.GetWindow(this);
                    imageWindows.Add(filename, imageWindow);
                    AddImageToMenus(filename);
                }
            }
        }
        private void PointOperations_Click(object sender, RoutedEventArgs e)
        {
            new PointOperationsWindow(this, app).ShowDialog();
        }
        public void CloseImageWindow(string filename)
        {
            app.RemoveImage(filename);
            imageWindows.Remove(filename);
            RemoveImgWindow(filename);
        }
        public void AddImageToMenus(string imageName)
        {
            string secureImageName = imageName.Replace("_", "__");
            if (!HistogramBtn.Items.Contains(secureImageName))
            {
                MenuItem histogramMenuItem = new MenuItem() { Header = secureImageName };
                histogramMenuItem.Click += (sender, e) =>
                {
                    MenuItem item = (MenuItem)e.Source;
                    string secureImageName = item.Header.ToString().Replace("__", "_");
                    imageWindows[secureImageName].MakeHistogram();
                };
                HistogramBtn.Items.Add(histogramMenuItem);
            }
            if (!SaveBtn.Items.Contains(secureImageName))
            {
                MenuItem saveMenuItem = new MenuItem() { Header = secureImageName };
                saveMenuItem.Click += (sender, e) =>
                {
                    MenuItem item = (MenuItem)e.Source;
                    string secureImageName = item.Header.ToString().Replace("__", "_");
                    imageWindows[secureImageName].Save();
                };
                SaveBtn.Items.Add(saveMenuItem);
            }
        }
        private void RemoveImgWindow(string tmpFileName)
        {
            imageWindows.Remove(tmpFileName);
            app.images.Remove(tmpFileName);
            string secureImageName = tmpFileName.Replace("_", "__");
            foreach (MenuItem item in HistogramBtn.Items)
            {
                if (item.Header.Equals(secureImageName))
                {
                    HistogramBtn.Items.Remove(item);
                    break;
                }
            }
            foreach (MenuItem item in SaveBtn.Items)
            {
                if (item.Header.Equals(secureImageName))
                {
                    SaveBtn.Items.Remove(item);
                    break;
                }
            }
            if (app.images.Count.Equals(0))
            {
                ImageMI.IsEnabled = false;
                SaveBtn.IsEnabled = false;
                PointOperations.IsEnabled = false;
            }

        }
    }
}
