using Microsoft.Win32;
using OnStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace OnStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string m="";
        public static Image global_sender;
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> ProductsCopy { get; set; }



        public MainWindow()
        {
            Products = new List<Product>()
            {

            new Product
            {
                Name="Cola",
                 Price=1.0,
                  ImagePath="Images/Cola.png",
                  Description="New Cola.Cola.MMC"
                
            },
            new Product
            {
                Name="Bread",
                 Price=0.50,
                  ImagePath="Images/Bread.png",
                  Description="Teze Corek"
                  
            },
            new Product
            {
                Name="Chips",
                 Price=2.40,
                  ImagePath="Images/Pringless.png",
                  Description="Pringless Cips"
                  
            },
            new Product
            {
                Name="Pizzza",
                 Price=9.99,
                  ImagePath="Images/Pizza.png",
                  Description="Pizza"
                  
            },
             new Product
            {
                Name="MixSalad",
                 Price=1.99,
                  ImagePath="Images/MixedSalad.png",
                  Description=" Super Salad"

            },
              new Product
            {
                Name="FastFoodMix",
                 Price=12.25,
                  ImagePath="Images/FastFood.jpg",
                  Description="Nice FastFood"
            }
              };
            ProductsCopy = Products;
            DataContext = this;
            InitializeComponent();

        }



        private void AddBTn_Click(object sender, RoutedEventArgs e)
        {
            if(Listbox.SelectedItem is Product item)
            {
                ProductImage.Source = new BitmapImage(new Uri(item.ImagePath, UriKind.RelativeOrAbsolute));
                Product = item;
                nameTxtBox.Text = item.Name;
                PriceTxtBox.Text = item.Price.ToString();
                DescriptionTxtBox.Text = item.Description;

            }
            else
            {
                MessageBox.Show("Select Product");
            }

            
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SearchTxtBox.Text = SearchTxtBox.Text.ToLower();
            Listbox.ItemsSource = null;
           ProductsCopy=ProductsCopy.Where(p => p.Name.Contains(SearchTxtBox.Text)).ToList();
            Listbox.ItemsSource = ProductsCopy;
            ProductsCopy = Products;
            if (string.IsNullOrWhiteSpace(SearchTxtBox.Text))
            {
                Listbox.ItemsSource = Products;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Product == null)
            {
                return;
            }
            if (ProductImage.Source != null)
            {
                Product.ImagePath = ProductImage.Source.ToString();

            }
            Product.Name = nameTxtBox.Text;
            Product.Price = Double.Parse(PriceTxtBox.Text);
            Product.Description = DescriptionTxtBox.Text;
            Listbox.ItemsSource = null;
            Listbox.ItemsSource = Products;

        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var open = new OpenFileDialog();

            open.Multiselect = false;
            open.Filter = "Image file (*.png)|*.png";

            if (open.ShowDialog() != true)
                return;

            var image = new BitmapImage(new Uri(open.FileName));

            var fileName = $@"Images/{Guid.NewGuid()}.png";

            if (!Directory.Exists("Images"))
                Directory.CreateDirectory("Images");

            image.Save(fileName);

            var fullFileName = Directory.GetCurrentDirectory() + "\\" + fileName;

            ProductImage.Source = new BitmapImage(new Uri(fullFileName));
        }

        private void ProductImage_Drop(object sender, DragEventArgs e)
        {
            ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;

            Image im = ((Image)sender);

            im.Source = image;
        }

        private void ProductImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //// sender – объект, на котором произошло данное событие.
            //Image lbl = sender as Image;
            //global_sender = lbl;
            //Создаем источник.
            // Копируем содержимое метки Drop.
            // 1 параметр: Элемент управления, который будет источником.
            // 2 параметр: Данные, которые будут перемещаться.
            // 3 параметр: Эффект при переносе.
            //DragDrop.DoDragDrop(lbl, lbl.Source, DragDropEffects.Copy);
        }

        private void ProductImage_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effects = DragDropEffects.Copy;
        }

        private void ProductImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;

            DataObject data = new DataObject(typeof(ImageSource), image.Source);

            DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (!Directory.Exists("Add ProductImage"))
            {
                Directory.CreateDirectory("Add ProductImage");
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var file in files)
            {
                m = file;

               
            }
            try
            {

                string dircopyfrom = m;

                string[] fileEnter1 = Directory.GetFiles(dircopyfrom);

                string dircopyto = $@"Add ProductImage";

                foreach (var f in fileEnter1)
                {
                    string filename = System.IO.Path.GetFileName(f);
                    File.Copy(f, dircopyto + "\\" + filename, true);
                    File.Delete(f);
                }
            }
            catch (Exception)
            {


            }
            File.Copy(m, $@"Add ProductImage/image.png", true);
            ProductImage.Source = new BitmapImage(new Uri(m));
        }


    }
}
