using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class RegistrationPg : Page
    {
        private RegistrationController registrationController;
        public RegistrationViewModel registrationViewModel;

        public RegistrationPg()
        {
            this.InitializeComponent();
            registrationController = new RegistrationController();
            registrationViewModel = registrationController.registrationViewModel;
            this.DataContext = registrationViewModel;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            registrationController.Register();
            Frame.Navigate(typeof(PendingApproval), null);
        }
    }
}
