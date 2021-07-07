using OnStore.Models;
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

namespace OnStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Product> Products = new List<Product>
        {
            new Product
            {
                Name="Cola",
                 Price=1.0,
                  ImagePath="Images/Cola.jpg"
            },
            new Product
            {
                Name="Bread",
                 Price=0.50,
                  ImagePath="Images/download.jpg"
            },
            new Product
            {
                Name="Cips",
                 Price=2.40,
                  ImagePath="Images/Cips.jpg"
            },
            new Product
            {
                Name="Pizzza",
                 Price=9.99,
                  ImagePath="Images/Pizza.png"
            },
             new Product
            {
                Name="MixSalad",
                 Price=1.99,
                  ImagePath="Images/MixedSalad.png"
            },
              new Product
            {
                Name="FastFoodMix",
                 Price=12.25,
                  ImagePath="Images/Cips.jpg"
            }
        };

        public MainWindow()
        {
            InitializeComponent();
            Listbox.ItemsSource = Products;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditListBox.ItemsSource = Listbox.ItemsSource;
        }
    }
}
