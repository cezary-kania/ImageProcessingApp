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

namespace ImageProcessingApp.Views
{
    /// <summary>
    /// Interaction logic for PosterizeWindow.xaml
    /// </summary>
    public partial class PosterizeWindow : Window
    {
        Models.Image img;
        ImageWindow parentWindow;
        public PosterizeWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.img = img;
            this.parentWindow = parentWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            uint levels;
            if (uint.TryParse(LevelsTB.Text, out levels))
            {
                levels = Math.Min(levels, 256);
                LevelsTB.Text = levels.ToString();
                Models.ImageOperations.Posterize(img, (int) levels);
            }
            else return;
            parentWindow.ReloadImage();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
