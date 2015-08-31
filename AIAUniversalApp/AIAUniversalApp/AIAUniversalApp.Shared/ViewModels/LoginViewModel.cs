using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIAUniversalApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public string UserName
        {
            get { return _username; }
            set
            {
                if (_username == value)
                {
                    return;
                }
                _username = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                {
                    return;
                }
                _password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
