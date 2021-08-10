using OnStore.Models;
using OnStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore.Extension
{
   public class Helper
    {
        public static MainWindow  mainWindow { get; set; }
        public static SignIn Signin { get; set; }
        public static ObservableCollection<User> Userlist { get; set; } = new ObservableCollection<User>();
    }
}
