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
    /// Interaction logic for PointOperationsWindow.xaml
    /// </summary>
    public partial class PointOperationsWindow : Window
    {
        private delegate Bitmap OperationExecute(Bitmap bmp1, Bitmap bmp2, object param);
        private MainWindow parentWindow;
        private Models.Application app;
        private Models.Image img;
        private double blendingalpha = 0.5;
        private double blendingbeta = 0.5;
        private double blendinggamma = -100;
        public PointOperationsWindow(MainWindow parentWindow, Models.Application app)
        {
            this.parentWindow = parentWindow;
            this.app = app;
            InitializeComponent();
            foreach (string image in app.images.Keys) Image1ComboBox.Items.Add(image);
            foreach (string image in app.images.Keys) Image2ComboBox.Items.Add(image);
            if (app.images.Count > 1)
                foreach (string key in operations.Keys) OperationComboBox.Items.Add(key);
            else
                OperationComboBox.Items.Add("NOT");
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Models.Image image1 = app.images[Image1ComboBox.SelectedItem.ToString()];
            Bitmap bitmap1 = image1.Bitmap;
            if (Image2ComboBox.SelectedItem == null)
            {
                img = new Models.Image();
                img.Bitmap = ExecuteOperation(bitmap1, null,null);
            }
            else
            {
                Models.Image image2 = app.images[Image2ComboBox.SelectedItem.ToString()];
                Bitmap bitmap2 = image2.Bitmap;
                img = new Models.Image();
                if (OperationComboBox.SelectedItem.ToString().Equals("Blending"))
                    img.Bitmap = ExecuteOperation(bitmap1, bitmap2, new object[] {blendingalpha,blendingbeta,blendinggamma});
                else
                    img.Bitmap = ExecuteOperation(bitmap1, bitmap2,null);
            }
            preview_image.Source = Utils.BitmapToImageSource(img.Bitmap);
        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            img.filename = app.RenderNewTmpName();
            app.images.Add(img.filename, img);
            ImageWindow imageWindow = new ImageWindow(parentWindow, img, app);
            parentWindow.imageWindows.Add(img.filename, imageWindow);
            imageWindow.Owner = Window.GetWindow(parentWindow);
            parentWindow.AddImageToMenus(img.filename);
            imageWindow.Show();
            Close();
        }
        private Dictionary<string, OperationExecute> operations = new Dictionary<string, OperationExecute>
        {
            {"Add", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.Add(bitmap1,bitmap2); } },
            //{"Blending", (bitmap1, bitmap2, param) => { return Models.ImageOperations.TwoArgsOperations.Blending(bitmap1,bitmap2,(double) param); } },
            {"Blending", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.Blending(bitmap1,bitmap2,param); } },
            {"OR", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.OR(bitmap1,bitmap2); } },
            {"AND", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.AND(bitmap1,bitmap2); } },
            {"XOR", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.XOR(bitmap1,bitmap2); } },
            {"NOT", (bitmap1, bitmap2, param) => { return Models.ImageOperations.EmguPointOperations.NOT(bitmap1); } },
        };
        private Bitmap ExecuteOperation(Bitmap bitmap1, Bitmap bitmap2, object param)
        {
            string operation = OperationComboBox.SelectedItem.ToString();
            return operations[operation](bitmap1, bitmap2, param);
        }
        private void Image1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Image2ComboBox.IsEnabled = true;
            TryEnableButton();
        }
        private void Image2ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (string key in operations.Keys)
                if (!OperationComboBox.Items.Contains(key))
                    OperationComboBox.Items.Add(key);
            if (!(OperationComboBox.SelectedItem == null) && OperationComboBox.SelectedItem.Equals("NOT")) OperationComboBox.SelectedItem = null;
            OperationComboBox.Items.Remove("NOT");
            TryEnableButton();
        }
        private void OperationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(OperationComboBox.SelectedItem == null) && OperationComboBox.SelectedItem.Equals("Blending"))
            {
                AlphaLB.IsEnabled = true;
                AlphaTB.IsEnabled = true;
                BetaLB.IsEnabled = true;
                BetaTB.IsEnabled = true;
                GammaLB.IsEnabled = true;
                GammaTB.IsEnabled = true;
            }
            else
            {
                AlphaLB.IsEnabled = false;
                AlphaTB.IsEnabled = false;
                BetaLB.IsEnabled = false;
                BetaTB.IsEnabled = false;
                GammaLB.IsEnabled = false;
                GammaTB.IsEnabled = false;
            }
                TryEnableButton();
        }
        private bool TryEnableButton()
        {
            return button.IsEnabled = ApplyBtn.IsEnabled = !(Image1ComboBox.SelectedItem == null)
                && ((!(Image2ComboBox.SelectedItem == null) && !(OperationComboBox.SelectedItem == null))
                || (!(OperationComboBox.SelectedItem == null) && OperationComboBox.SelectedItem.Equals("NOT")));
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BlendingRatioTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((double.TryParse(AlphaTB.Text, out blendingalpha) && TryEnableButton() && blendingalpha <= 1 && blendingalpha >= 0) 
                &&
                (double.TryParse(BetaTB.Text, out blendingbeta) && TryEnableButton() && blendingbeta <= 1 && blendingbeta >= 0)
                &&
                (double.TryParse(GammaTB.Text, out blendinggamma) && TryEnableButton()))
                button.IsEnabled = ApplyBtn.IsEnabled = true;
            else
                button.IsEnabled = ApplyBtn.IsEnabled = false;
        }
    }
}
