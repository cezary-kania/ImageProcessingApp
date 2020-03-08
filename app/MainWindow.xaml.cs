using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace APO_v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, ImageWindow> images = new Dictionary<string, ImageWindow>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                
                string orginalFileName = openFileDialog.FileName;
                string tmpfileName = orginalFileName;
                for (int i = 1; images.Keys.Contains(tmpfileName); ++i)
                    tmpfileName = string.Format("{0}({1}).{2} ",orginalFileName.Split('.')[0],i,orginalFileName.Split('.')[1]);
                ImageWindow newImgW = new ImageWindow(orginalFileName, tmpfileName, this);
                images.Add(tmpfileName, newImgW);
                Lab1MenuI.IsEnabled = true;
                AddImageToHistogramMenu(tmpfileName);
            }   
        }
        private void AddImageToHistogramMenu(string imageName)
        {
            string secureImageName = imageName.Replace("_", "__");
            if (!HistogramBtn.Items.Contains(secureImageName))
            {
                MenuItem histogramMenuItem = new MenuItem() { Header = secureImageName };
                histogramMenuItem.Click += histogramMenuItem_Click;
                HistogramBtn.Items.Add(histogramMenuItem);
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWindows();
            this.Close();
        }
        private void CloseAllWindows()
        {
            foreach (ImageWindow window in images.Values)
            {
                window.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAllWindows();
        }

        private void histogramMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem) e.Source;
            string secureImageName = item.Header.ToString().Replace("__", "_");
            images[secureImageName].MakeHistogram();
        }
        public void RemoveImgWindow(string tmpFileName)
        {
            images.Remove(tmpFileName);
            string secureImageName = tmpFileName.Replace("_", "__");
            foreach (MenuItem item in HistogramBtn.Items)
            {
                if (item.Header.Equals(secureImageName))
                {
                    HistogramBtn.Items.Remove(item);
                    break;
                }
                   
            }
            if(HistogramBtn.Items.Count.Equals(0)) Lab1MenuI.IsEnabled = false;
        }
    }
}
