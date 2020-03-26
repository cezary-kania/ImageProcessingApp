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
    /// Interaction logic for ThresholdingWindow.xaml
    /// </summary>
    public partial class ThresholdingWindow : Window
    {
        private ImageWindow parentWindow;
        public ThresholdingWindow(ImageWindow parentWindow)
        {
            this.parentWindow = parentWindow;
            InitializeComponent();

            p1_slider.Maximum = parentWindow.GetMaximumLuminance();
            p1_slider.Minimum = 0;
            p1_TB.Text = (parentWindow.GetMaximumLuminance() / 2).ToString();
            p1_slider.Value = parentWindow.GetMaximumLuminance() / 2;
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ApplyBitmapChange();
            Close();
        }
        private void CB_2_Checked(object sender, RoutedEventArgs e)
        {
            parentWindow.OnePBinaryThresholingWithKeepingL((int)p1_slider.Value);
        }
        private void p1_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newValue = (int)((Slider)sender).Value;
            p1_TB.Text = newValue.ToString();
            if (!(bool)CB_2.IsChecked)
                parentWindow.OnePBinaryThresholing(newValue);
            else
                parentWindow.OnePBinaryThresholingWithKeepingL(newValue);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parentWindow.RestoreCopyIfExist();
        }
        private void p1_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            byte newP1;
            if (!byte.TryParse(((TextBox)sender).Text, out newP1))
            {
                p1_slider.IsEnabled = !p1_slider.IsEnabled;
                ApplyBtn.IsEnabled = !ApplyBtn.IsEnabled;
                return;
            };
            p1_slider.IsEnabled = true;
            ApplyBtn.IsEnabled = true;
            p1_slider.Value = newP1;
            if (!(bool)CB_2.IsChecked)
                parentWindow.OnePBinaryThresholing(newP1);
            else
                parentWindow.OnePBinaryThresholingWithKeepingL(newP1);
        }
    }
}
