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

namespace APO_v1
{
    /// <summary>
    /// Interaction logic for LumRangeStrWindow.xaml
    /// </summary>
    public partial class LumRangeStrWindow : Window
    {
        Models.Image img;
        ImageWindow imageWindow;
        private int p1;
        private int p2;
        public LumRangeStrWindow(Models.Image img, ImageWindow imageWindow)
        {
            InitializeComponent();
            this.img = img;
            this.imageWindow = imageWindow;
            p1_TB.Text = (p1 = 0).ToString();
            p2_TB.Text = (p2 = img.LUT[0].Length - 1).ToString();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            img.LumRangeStretching((uint) p1, (uint) p2);
            imageWindow.ReloadImage();
        }

        private void p1_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = int.TryParse(p1_TB.Text, out p1) && p1 < p2;
        }

        private void p2_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyBtn.IsEnabled = int.TryParse(p2_TB.Text, out p2) && p1 < p2;
        }
    }
}
