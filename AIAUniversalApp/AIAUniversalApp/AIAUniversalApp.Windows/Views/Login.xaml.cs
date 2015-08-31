using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AIAUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {

        private LoginController loginController;
        private LoginViewModel loginViewModel;

        public Login()
        {
            this.InitializeComponent();
            loginController = new LoginController();
            loginViewModel = loginController.loginViewModel;
            this.DataContext = loginViewModel;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePg), null);
            //bool isValidData = validateData(loginViewModel.UserName, loginViewModel.Password);
            //if (isValidData)
            //{
            //    Frame.Navigate(typeof(HomePg), null);
            //}
         
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPg), null);
        }

        /*
        private bool validateData(string username, string password)
        {
            bool validUser = checkUsername(username);
            bool validPass = checkPassword(password);

            return validUser && validPass;
        }

        private bool checkUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                usernameTextBoxError.Text = "Username cannot be empty.";
                return false;
            }
            else
            {
                usernameTextBoxError.Text = "";
                return true;
            }
        }

        private bool checkPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                passwordTextBoxError.Text = "Password cannot be empty.";
                return false;
            }
            else
            {
                passwordTextBoxError.Text = "";
                return true;
            }
        }
        */

    }
}
