using OnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnStore.Chain_Of_Responsibility
{
    public class SignUpChain : IChain
    {
        public IChain nextChain { get ; set ; }

        public void Handle(User user)
        {
            if (user.StepsOfChain == "SingUp Chain" && user.Name != string.Empty &&  user.Password != string.Empty && user.Email != string.Empty )
            {


                nextChain.Handle(user);

            }

            if (user.StepsOfChain == "SingUp Chain" && (user.Name == string.Empty || user.Password == string.Empty || user.Email == string.Empty ))
            {
                //  NextChain.User_if_else(user);
                MessageBox.Show($"Can not sing up", "First Chain");
            }
        }

        public void setNextChain(IChain chain)
        {
            nextChain = chain;
        }
    }
}
