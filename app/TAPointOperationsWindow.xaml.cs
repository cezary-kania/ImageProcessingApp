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

namespace APO_v1
{
    /// <summary>
    /// Interaction logic for TAPointOperationsWindow.xaml
    /// </summary>
    public partial class TAPointOperationsWindow : Window
    {
        private delegate Bitmap OperationExecute(Bitmap bmp1, Bitmap bmp2);
        private Dictionary<string, ImageWindow> images;
        MainWindow parentWindow;
        public TAPointOperationsWindow(MainWindow parentWindow, Dictionary<string, ImageWindow> images)
        {
            this.images = images;
            this.parentWindow = parentWindow;
            InitializeComponent();
            foreach (string image in images.Keys) Image1ComboBox.Items.Add(image);
            foreach (string image in images.Keys) Image2ComboBox.Items.Add(image);
            if(images.Count > 1)
                foreach (string key in operations.Keys) OperationComboBox.Items.Add(key);
            else
                OperationComboBox.Items.Add("NOT");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow imageWindow1 = images[Image1ComboBox.SelectedItem.ToString()];
            Bitmap bitmap1 = imageWindow1.img.Bitmap;
            Models.Image img;
            if (Image2ComboBox.SelectedItem == null)
            {
                img = new Models.Image();
                img.Bitmap = ExecuteOperation(bitmap1, null);
            }
            else
            {
                ImageWindow imageWindow2 = images[Image2ComboBox.SelectedItem.ToString()];
                Bitmap bitmap2 = imageWindow2.img.Bitmap;
                img = new Models.Image();
                img.Bitmap = ExecuteOperation(bitmap1, bitmap2);
            }
            img.TmpfileName = parentWindow.RenderNewTmpName(img.OrginalFileName);
            ImageWindow imageWindow = new ImageWindow(parentWindow, img);
            images.Add(img.TmpfileName, imageWindow);
            imageWindow.Show();
            Close();
        }
        private Dictionary<string, OperationExecute> operations = new Dictionary<string, OperationExecute>
        {
            {"Add", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.Add(bitmap1,bitmap2); } },
            {"Blending", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.Blending(bitmap1,bitmap2); } },
            {"OR", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.OR(bitmap1,bitmap2); } },
            {"AND", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.AND(bitmap1,bitmap2); } },
            {"XOR", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.XOR(bitmap1,bitmap2); } },
            {"NOT", (bitmap1, bitmap2) => { return Models.TwoArgsOperations.NOT(bitmap1); } },
        };
        private Bitmap ExecuteOperation(Bitmap bitmap1, Bitmap bitmap2)
        {
            string operation = OperationComboBox.SelectedItem.ToString();
            return operations[operation](bitmap1, bitmap2);
        }
        private void Image1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image2ComboBox.IsEnabled = true;
            TryEnableButton();
        }
        private void Image2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(OperationComboBox.SelectedItem == null) && OperationComboBox.SelectedItem.Equals("NOT")) OperationComboBox.SelectedItem = null;
            OperationComboBox.Items.Remove("NOT");
            TryEnableButton();
        }
        private void OperationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TryEnableButton();
        }
        private void TryEnableButton()
        {
            button.IsEnabled = !(Image1ComboBox.SelectedItem == null) 
                && ((!(Image2ComboBox.SelectedItem == null) && !(OperationComboBox.SelectedItem == null))
                || (!(OperationComboBox.SelectedItem == null) && OperationComboBox.SelectedItem.Equals("NOT")));
        }
    }
}
