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
            p1_TB.Text = 0.ToString();
            p1_slider.Value = parentWindow.GetMaximumLuminance() / 2;
            p2_slider.Maximum = parentWindow.GetMaximumLuminance();
            p2_slider.Minimum = 0;
        }

        private void p2_CB_Checked(object sender, RoutedEventArgs e)
        {
            p2_label.IsEnabled = true;
            p2_slider.IsEnabled = true;
            p2_TB.IsEnabled = true;
            p2_slider.Value = parentWindow.GetMaximumLuminance();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ApplyBitmapChange();
            Close();
        }
        private void CB_2_Checked(object sender, RoutedEventArgs e)
        {
            if (!(bool)p2_CB.IsChecked)
                parentWindow.OnePBinaryThresholingWithKeepingL((int)p1_slider.Value);
            else
                parentWindow.TwoPBinaryThresholingWithKeepingL((int)p1_slider.Value, (int)p2_slider.Value);
        }

        private void p1_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newValue = (int)((Slider)sender).Value;
            if (newValue >= p2_slider.Value && (bool)p2_CB.IsChecked)
            {
                p2_slider.Value = Math.Min(newValue + 1, parentWindow.GetMaximumLuminance());
            }
            p1_TB.Text = newValue.ToString();
            if (!(bool)p2_CB.IsChecked && !(bool)CB_2.IsChecked)
                parentWindow.OnePBinaryThresholing(newValue);
            else if((bool)CB_2.IsChecked && !(bool)p2_CB.IsChecked)
                parentWindow.OnePBinaryThresholingWithKeepingL(newValue);
            else if(!(bool)CB_2.IsChecked && (bool)p2_CB.IsChecked)
                parentWindow.TwoPBinaryThresholing(newValue, (int)p2_slider.Value);
            else
                parentWindow.TwoPBinaryThresholingWithKeepingL(newValue, (int)p2_slider.Value);
            parentWindow.ReloadImage();
        }

        private void p2_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            p2_label.IsEnabled = false;
            p2_slider.IsEnabled = false;
            p2_TB.IsEnabled = false;
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
            if (!(bool)p2_CB.IsChecked && !(bool)CB_2.IsChecked)
                parentWindow.OnePBinaryThresholing(newP1);
            else if ((bool)CB_2.IsChecked && !(bool)p2_CB.IsChecked)
                parentWindow.OnePBinaryThresholingWithKeepingL(newP1);
            else if (!(bool)CB_2.IsChecked && (bool)p2_CB.IsChecked)
                parentWindow.TwoPBinaryThresholing(newP1, (int)p2_slider.Value);
            else
                parentWindow.TwoPBinaryThresholingWithKeepingL(newP1, (int)p2_slider.Value);

            parentWindow.ReloadImage();
        }

        private void p2_TB_LostFocus(object sender, RoutedEventArgs e)
        {
            byte newP2;
            if (!byte.TryParse(((TextBox)sender).Text, out newP2) || newP2 <= p1_slider.Value)
            {
                p2_slider.IsEnabled = false;
                ApplyBtn.IsEnabled = false;
                return;
            };
            p2_slider.IsEnabled = true;
            ApplyBtn.IsEnabled = true;
            p2_slider.Value = newP2;
            if (!(bool)CB_2.IsChecked)
                parentWindow.TwoPBinaryThresholing((int)p1_slider.Value,newP2);
            else
                parentWindow.TwoPBinaryThresholingWithKeepingL((int)p1_slider.Value, newP2);


            parentWindow.ReloadImage();
        }

        private void p2_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if(slider.Value <= p1_slider.Value)
            {
                slider.Value = p1_slider.Value + 1;
            }
            int newValue = (int) slider.Value;

            p2_TB.Text = newValue.ToString();
            if (!(bool)CB_2.IsChecked)
                parentWindow.TwoPBinaryThresholing((int)p1_slider.Value, newValue);
            else
                parentWindow.TwoPBinaryThresholingWithKeepingL((int)p1_slider.Value, newValue);

            parentWindow.ReloadImage();
        }
    }
}
