using AIARestApi;
using AIAUniversalApp.Controllers;
using AIAUniversalApp.Shared.Helpers;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AIAUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuoteSummary : Page
    {
        public ActiveQuoteViewModel activeQuoteViewModel;
        private QuoteController quoteController;
        public int count =1;
        public int count2 =1;

        public QuoteSummary()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ActiveQuoteViewModel)
            {
                quoteController = new QuoteController();
                activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
                quoteController.activeQuoteViewModel = activeQuoteViewModel;
                quoteController.activeQuoteViewModel.CustomerAddress = activeQuoteViewModel.Drivers[0].Address;
                quoteController.activeQuoteViewModel.CustomerDob = activeQuoteViewModel.Drivers[0].Dob.DateTime;
                quoteController.activeQuoteViewModel.CustomerName = activeQuoteViewModel.Drivers[0].FirstName + " " + activeQuoteViewModel.Drivers[0].LastName;
                quoteController.activeQuoteViewModel.CustomerPhone = activeQuoteViewModel.Drivers[0].Phone;
                quoteController.activeQuoteViewModel.CustomerSsn = activeQuoteViewModel.Drivers[0].Ssn;
                quoteController.activeQuoteViewModel.Id = activeQuoteViewModel.Id = activeQuoteViewModel.q.Id;
                quoteController.activeQuoteViewModel.State = Enum.GetName(typeof(State), activeQuoteViewModel.Drivers[0].LicenseState);
            }
            else if (e.Parameter is long)
            {
                quoteController = new QuoteController((long)e.Parameter);
                activeQuoteViewModel = quoteController.activeQuoteViewModel;
            }
            this.DataContext = activeQuoteViewModel;
            driversList.ItemsSource = activeQuoteViewModel.Drivers;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            quoteController.Submit();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            quoteController.Save();
        }

        private void Driver_Click(object sender, RoutedEventArgs e)
        {
            count++;

            if (count % 2 == 0) 
            {
                driversList.Visibility = Visibility.Visible;
            }
            else
            {
                driversList.Visibility = Visibility.Collapsed;
            }
       }
            

        private void Vehicle_Click(object sender, RoutedEventArgs e)
        {
            count2++;

            if (count2 % 2 == 0)
            {
                CarStuff.Visibility = Visibility.Visible;
            }
            else
            {
                CarStuff.Visibility = Visibility.Collapsed;
            }
        }

        private void Price_Click(object sender, RoutedEventArgs e)
        {
        }




    }
}
