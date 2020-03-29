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
    /// Interaction logic for RangeStrWindow.xaml
    /// </summary>
    public partial class RangeStrWindow : Window
    {
        Models.Image img;
        ImageWindow imageWindow;
        private uint p1, p2, q3, q4;
        public RangeStrWindow(Models.Image img, ImageWindow imageWindow)
        {
            InitializeComponent();
            this.img = img;
            this.imageWindow = imageWindow;
            p1_TB.Text = (p1 = 0).ToString();
            p2_TB.Text = (p2 = 255).ToString();
            q3_TB.Text = (q3 = 0).ToString();
            q4_TB.Text = (q4 = 255).ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Models.ImageOperations.RangeStretching(img, p1, p2, q3, q4);
            imageWindow.ReloadImage();
        }

        private void p1_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(p1_TB.Text, out p1) && p1 < p2 && p1 <= 255;
        }

        private void p2_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(p2_TB.Text, out p2) && p1 < p2 && p2 <= 255;
        }

        private void q3_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(q3_TB.Text, out q3) && q3 < q4 && q3 <= 255;
        }

        private void q4_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = uint.TryParse(q4_TB.Text, out q4) && q3 < q4 && q4 <= 255;
        }
    }
}
