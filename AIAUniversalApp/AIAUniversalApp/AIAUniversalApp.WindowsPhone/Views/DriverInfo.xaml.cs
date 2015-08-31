using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class DriverInfo : Page
    {
        private DriverController dc;
        public DriverViewModel driverViewModel;
        private ActiveQuoteViewModel activeQuoteViewModel;

        public DriverInfo()
        {
            this.InitializeComponent();
            Gender.ItemsSource = Enum.GetValues(typeof(Gender));
            StateList.ItemsSource = Enum.GetValues(typeof(State));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
            dc = new DriverController(activeQuoteViewModel.q.Id);
            this.DataContext = dc.DriverViewModel;
            driverViewModel = dc.DriverViewModel;
        }


        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            activeQuoteViewModel.Drivers.Add(driverViewModel);
            dc.Save(activeQuoteViewModel.q.Id);
            ((Frame)Window.Current.Content).Navigate(typeof(DriverInfo), activeQuoteViewModel);

        }
        
        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            activeQuoteViewModel.Drivers.Add(driverViewModel);
            dc.Save(activeQuoteViewModel.q.Id);
            ((Frame)Window.Current.Content).Navigate(typeof(VehicleInfo), activeQuoteViewModel);
        }


        private void One_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;

        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;


        }


        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;

        }

        private void Gender_Click(ListPickerFlyout sender, ItemsPickedEventArgs e)
        {
            GenderButton.Content = Enum.GetName(typeof(Gender), driverViewModel.Gender);
        }

        private void State_Click(ListPickerFlyout sender, ItemsPickedEventArgs e)
        {
            StateButton.Content = Enum.GetName(typeof(State), driverViewModel.LicenseState);
        }
    }
}
