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
    /// Interaction logic for LuminanceLvlRedWindow.xaml
    /// </summary>
    public partial class LuminanceLvlRedWindow : Window
    {
        Models.Image img;
        ImageWindow parentWindow;
        public LuminanceLvlRedWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            this.img = img;
            this.parentWindow = parentWindow;
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            img.RestoreCopyIfExists();
            Close();
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            uint levels;
            if (uint.TryParse(LevelsTB.Text, out levels))
            {
                levels = Math.Min(levels, (uint)img.LUT[0].Length);
                LevelsTB.Text = levels.ToString();
                img.Posterize((int)levels);
            }
            else return;
            parentWindow.ReloadImage();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            img.RemoveCopyIfExists();
        }
    }
}
