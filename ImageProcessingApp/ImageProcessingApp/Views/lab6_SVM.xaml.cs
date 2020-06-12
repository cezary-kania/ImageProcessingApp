using ImageProcessingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageProcessingApp.Views
{
    /// <summary>
    /// Interaction logic for lab6_SVM.xaml
    /// </summary>
    public partial class lab6_SVM : Window
    {
        private HashSet<string> filenames = new HashSet<string>();
        private ObservableCollection<string> safeFilenames = new ObservableCollection<string>();
        private Emgu.CV.ML.SVM svm;
        private Bitmap predictBmp;
        public lab6_SVM()
        {
            InitializeComponent();
            FilesList.ItemsSource = safeFilenames;
            PredictBtn.IsEnabled = false;
            TrainBtn.IsEnabled = false;
            AddPImage.IsEnabled = false;
        }

        private void PredictBtn_Click(object sender, RoutedEventArgs e)
        {
            predictBmp = ImageOperations.Lab6.Predict(svm, predictBmp, filenames.Count);
            preview_img.Source = Utils.BitmapToImageSource(predictBmp);
        }

        private void TrainBtn_Click(object sender, RoutedEventArgs e)
        {
            svm = ImageOperations.Lab6.Train(filenames);
            AddPImage.IsEnabled = true;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddTrImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filenames.Add(openFileDialog.FileName);
                safeFilenames.Add(openFileDialog.SafeFileName);

            }
            TrainBtn.IsEnabled = filenames.Count > 0;
        }

        private void AddPImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                predictBmp = new Bitmap(openFileDialog.FileName);
                preview_img.Source = Utils.BitmapToImageSource(predictBmp);
                PredictBtn.IsEnabled = true;
            }
        }
    }
}
