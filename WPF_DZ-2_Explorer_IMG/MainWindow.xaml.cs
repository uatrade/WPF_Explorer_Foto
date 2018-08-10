using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPF_DZ_2_Explorer_IMG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dirname;
        Image newImage;
        BitmapImage src;
        double size = 1;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            SliderSize.ValueChanged += SliderSize_ValueChanged;
        }

        private void SliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
          
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChoseDir_Click(object sender, RoutedEventArgs e)
        {
            

            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            

            if(result == System.Windows.Forms.DialogResult.OK)
            {
                dirname = dialog.SelectedPath;
            }
            

            DirectoryInfo dir = new DirectoryInfo(dirname);
            FileInfo[] dirs = dir.GetFiles();

            foreach (var item in dirs)
            {
                if(item.Extension==".png"|| item.Extension == ".jpg")
                AddImage(System.IO.Path.GetFullPath(item.FullName.ToString()));
            }

        }

        private void AddImage(string imagePath)
        {
            Image newImage = new Image();
            BitmapImage src = new BitmapImage();

            Button btn = new Button();

            src.BeginInit();

            src.UriSource = new Uri(imagePath, UriKind.Absolute);
            src.EndInit();

            newImage.Source = src;
            newImage.Stretch = Stretch.Uniform;
            newImage.MaxHeight = 150;
            newImage.MaxWidth = 150;
            newImage.Margin = new Thickness(4, 4, 4, 4);

            ListBoxFoto.Items.Add(newImage);
            newImage.MouseDown += NewImage_MouseDown;
        }

        private void MainImage(string imagePath)
        {
            newImage = new Image();
            src = new BitmapImage();


            src.BeginInit();
            src.UriSource = new Uri(imagePath, UriKind.Absolute);
            src.EndInit();

            mainImage.Source = src;
            mainImage.Stretch = Stretch.Uniform;
            //mainImage.MaxHeight = 250;
            //mainImage.MaxWidth = 250;
            //mainImage.Height = 200;
            //mainImage.Width = 200;
            mainImage.Margin = new Thickness(4, 4, 4, 4);
        }

        private void NewImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show((sender as Image).Source.ToString());
            MainImage((sender as Image).Source.ToString() );
        }
    }
}
