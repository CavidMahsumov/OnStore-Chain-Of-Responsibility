using OnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore.Chain_Of_Responsibility
{
    public class SignInChain : IChain
    {
        public IChain nextChain { get ; set ; }

        public void Handle(User user)
        {
            if (user.StepsOfChain == "SingIn Chain" && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Email) )
            {
                nextChain.Handle(user);

            }
        }

        public void setNextChain(IChain chain)
        {
            nextChain = chain;
        }
    }
}
