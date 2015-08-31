using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class VehicleInfo : Page
    {
        private VehicleController vc;
        public VehicleViewModel vehicleViewModel;
        private ActiveQuoteViewModel activeQuoteViewModel;
        private bool controllerSave;

        public VehicleInfo()
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
            activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
            vc = new VehicleController(activeQuoteViewModel.Drivers, activeQuoteViewModel.q.Id,
                activeQuoteViewModel.Drivers.First().ID);
            this.DataContext = vc.VehicleViewModel;
            vehicleViewModel = vc.VehicleViewModel;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);

            PrimaryDriver.ItemsSource = vehicleViewModel.Drivers;
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

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);
            controllerSave = true;
            Frame.Navigate(typeof(VehicleInfo), activeQuoteViewModel);
        }

        private void VehicleInfo3PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
        }

        private void QuoteSummary_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);
            controllerSave = true;
            Frame.Navigate(typeof(QuoteSummary), activeQuoteViewModel);
        }


        private void PrimaryDriver_Picked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            vehicleViewModel.DriverId = ((DriverViewModel)PrimaryDriver.SelectedValue).ID;
            PrimaryDriverButton.Content = ((DriverViewModel)PrimaryDriver.SelectedValue).FirstName;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (controllerSave)
            {
                vc.Save(activeQuoteViewModel.q.Id);
            }
        }
    }
}
