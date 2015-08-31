using AIARestApi;
using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
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
    public sealed partial class VehicleInfoPg : Page
    {
        private VehicleController vc;
        public VehicleViewModel vehicleViewModel;
        private ActiveQuoteViewModel activeQuoteViewModel;
        
        public VehicleInfoPg()
        {
            this.InitializeComponent();
            ((TextBlock)VehicleTopNav.FindName("VehicleTopNavTextBlock")).FontWeight = FontWeights.Bold;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
            vc = new VehicleController(activeQuoteViewModel.Drivers, activeQuoteViewModel.q.Id, 
                activeQuoteViewModel.Drivers.First().ID);
            this.DataContext = vc.VehicleViewModel;
            vehicleViewModel = vc.VehicleViewModel;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);
        }

        private void VehicleInfo1NextButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
        }

        private void VehicleInfo2PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
        }
        private void VehicleInfo2NextButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;
        }

        private void AddAnotherVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);
            vc.Save(activeQuoteViewModel.q.Id);
            Frame.Navigate(typeof(VehicleInfoPg), activeQuoteViewModel);
        }

        private void VehicleInfo3PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
        }

        private void QuoteSummaryButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Vehicles.Add(vehicleViewModel);
            vc.Save(activeQuoteViewModel.q.Id);
            Frame.Navigate(typeof(QuotePg), activeQuoteViewModel);
        }
    }
}
