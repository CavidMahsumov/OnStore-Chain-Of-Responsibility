using OnStore.Chain_Of_Responsibility;
using OnStore.Extension;
using OnStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace OnStore.View
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        

        public MainWindow OrderViewModel_UCs { get; set; }


        public bool singinclick = false;

        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List { get { return _User_List; } set { _User_List = value; } }

        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();
       public ObservableCollection<User> List { get; set; } = new ObservableCollection<User>();



        string stepofchain = "SingIn Chain";
        public SignIn()
        {
            InitializeComponent();
            Helper.Signin = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            MainGrid.Children.Add(signUp);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            List = Helper.Userlist;
           
            foreach (var item in List)
            {
                if (item.Email == emailtxtBox.Text && item.Password == passwordtxtpox.Text)
                {
                    MessageBox.Show($"Welcome livE store {item.Name}");

                    singinclick = true;


                  
                }


            }

            if (!List.Any())
            {


                IChain chain = new SignUpChain();
                IChain chain2 = new SignInChain();
                IChain chain3 = new OrderChain();

                chain.setNextChain(chain2);
                chain2.setNextChain(chain3);

                User User = new User { Email = emailtxtBox.Text, Password = passwordtxtpox.Text, StepsOfChain = stepofchain };
                chain2.Handle(User);
                singinclick = false;
            }


            if (!User_List.Any(x => x.Email == emailtxtBox.Text) || !User_List.Any(x => x.Password == passwordtxtpox.Text))
            {

                IChain chain = new SignUpChain();
                IChain chain2 = new SignInChain();
                IChain chain3 = new OrderChain();

                chain.setNextChain(chain2);
                chain2.setNextChain(chain3);

                User User = new User { Email= emailtxtBox.Text, Password= passwordtxtpox.Text,StepsOfChain= stepofchain };
                chain2.Handle(User);

                singinclick = false;
            }

            
        }
    }
}
