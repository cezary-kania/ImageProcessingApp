using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for MaskConvolutionWindow.xaml
    /// </summary>
    public partial class MaskConvolutionWindow : Window
    {
        public MaskConvolutionWindow(Models.Image img, ImageWindow parentWindow)
        {
            InitializeComponent();
            foreach (string key in sharpenMasks.Keys) maskCB.Items.Add(key);
            foreach (string key in blurringMasks.Keys) blurringMaskCB.Items.Add(key);
            maskCB.SelectedIndex = blurringMaskCB.SelectedIndex = 0;
            BorderOpCB.Items.Add("replicate");
            BorderOpCB.Items.Add("reflect");
            BorderOpCB.Items.Add("isolated");
            BorderOpCB.SelectedIndex = 0;
            ReloadSharpenMask();
            ReloadBlurringMask();
            this.parentWindow = parentWindow;
            this.img = img;
            prev_image = new Models.Image();
            CloneOrginalImage();
        }

        private void bluringMaskCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadBlurringMask();
        }
        private ImageWindow parentWindow;
        private Models.Image img;
        private Models.Image prev_image;
        private Dictionary<string, float[,]> sharpenMasks = new Dictionary<string, float[,]>()
        {
            { "Mask 1", new float[,]{{0,-1,0 },{ -1, 4, -1 },{0,-1,0}} },
            { "Mask 2", new float[,]{{ -1, -1, -1 },{ -1, 8, -1 },{ -1, -1, -1 } } },
            { "Mask 3", new float[,]{{ 1, -2, 1 },{ -2, 4, -2 },{ 1, -2, 1 } } },
        };
        private Dictionary<string, float[,]> blurringMasks = new Dictionary<string, float[,]>()
        {
            { "Mask 1", new float[,]{{1,2,1 },{ 2, 4, 2 },{1,2,1}} },
            { "Mask 2", new float[,]{{ 1,1,1 },{ 1,1,1 },{ 1,1,1 } } },
        };
        private void CloneOrginalImage()
        {
            prev_image.Bitmap = (Bitmap)img.Bitmap.Clone();
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            img.Bitmap = (Bitmap)prev_image.Bitmap.Clone();
            parentWindow.ReloadImage();
            Close();
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ExecuteBtn_Click(object sender, RoutedEventArgs e)
        {
            CloneOrginalImage();
            string sMask = maskCB.SelectedItem.ToString();
            string bMask = blurringMaskCB.SelectedItem.ToString();
            float[,] mask5x5 = Models.ImageOperations.EmguNeighborhoodOp.MasksConvolution(sharpenMasks[sMask], blurringMasks[bMask]);
            prev_image.Bitmap = Models.ImageOperations.EmguNeighborhoodOp.Filter2D(prev_image.Bitmap, mask5x5, BorderOpCB.SelectedItem.ToString());
            preview_image.Source = Utils.BitmapToImageSource(prev_image.Bitmap);
            FillResultMask(mask5x5);
        }
        private void FillResultMask(float[,] mask)
        {
            TextBox[] m3_textBoxes = new TextBox[] {
                m3_0, m3_1, m3_2, m3_3,m3_4, m3_5, m3_6, m3_7, m3_8, m3_9, m3_10,
                m3_11, m3_12, m3_13, m3_14, m3_15, m3_16, m3_17, m3_18, m3_19, 
                m3_20, m3_21, m3_22, m3_23, m3_24
            };
            for (int i = 0; i < m3_textBoxes.Length; ++i)
            {
                int row = i / 5;
                int col = i % 5;
                m3_textBoxes[i].Text = mask[row, col].ToString();
            }
           
        }
        private void ReloadSharpenMask()
        {
            string maskKey = maskCB.SelectedItem.ToString();
            m0.Text = sharpenMasks[maskKey][0, 0].ToString();
            m1.Text = sharpenMasks[maskKey][0, 1].ToString();
            m2.Text = sharpenMasks[maskKey][0, 2].ToString();
            m3.Text = sharpenMasks[maskKey][1, 0].ToString();
            m4.Text = sharpenMasks[maskKey][1, 1].ToString();
            m5.Text = sharpenMasks[maskKey][1, 2].ToString();
            m6.Text = sharpenMasks[maskKey][2, 0].ToString();
            m7.Text = sharpenMasks[maskKey][2, 1].ToString();
            m8.Text = sharpenMasks[maskKey][2, 2].ToString();
        }
        private void ReloadBlurringMask()
        {
            string maskKey = blurringMaskCB.SelectedItem.ToString();
            m2_0.Text = blurringMasks[maskKey][0, 0].ToString();
            m2_1.Text = blurringMasks[maskKey][0, 1].ToString();
            m2_2.Text = blurringMasks[maskKey][0, 2].ToString();
            m2_3.Text = blurringMasks[maskKey][1, 0].ToString();
            m2_4.Text = blurringMasks[maskKey][1, 1].ToString();
            m2_5.Text = blurringMasks[maskKey][1, 2].ToString();
            m2_6.Text = blurringMasks[maskKey][2, 0].ToString();
            m2_7.Text = blurringMasks[maskKey][2, 1].ToString();
            m2_8.Text = blurringMasks[maskKey][2, 2].ToString();
        }
        private void maskCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadSharpenMask();
        }
    }
}
