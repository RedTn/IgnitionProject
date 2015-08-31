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
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.Extensions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AIAUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DriverInfoPg : Page
    {
        private DriverController dc;
        private ActiveQuoteViewModel activeQuoteViewModel;
        public DriverViewModel driverViewModel;

        public DriverInfoPg()
        {
            this.InitializeComponent();
            Gender.ItemsSource = Enum.GetValues(typeof(Gender));
            StateList.ItemsSource = Enum.GetValues(typeof(State));
            ((TextBlock)DriverTopNav.FindName("DriverTopNavTextBlock")).FontWeight = FontWeights.Bold;
        }

        private void DriverInfo1NextButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
            
        }

        private void DriverInfo2PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
        }
        private void DriverInfo2NextButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Visible;
        }

        private void DriverInfo3PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Visible;
            Page3.Visibility = Visibility.Collapsed;
        }
        private void DriverInfo3NextButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Collapsed;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Drivers.Add(dc.DriverViewModel);
            controllerSave = true;
            Frame.Navigate(typeof(VehicleInfoPg), activeQuoteViewModel);
        }

        private void AddAnotherDriverButton_Click(object sender, RoutedEventArgs e)
        {
            Page1.Visibility = Visibility.Visible;
            Page2.Visibility = Visibility.Collapsed;
            Page3.Visibility = Visibility.Collapsed;
            activeQuoteViewModel.Drivers.Add(dc.DriverViewModel);
            controllerSave = true;
            Frame.Navigate(typeof(DriverInfoPg), activeQuoteViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
            dc = new DriverController(activeQuoteViewModel.q.Id);
            controllerSave = false;
            this.DataContext = dc.DriverViewModel;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (controllerSave)
            {
                dc.Save(activeQuoteViewModel.q.Id);
            }
        }

        private bool controllerSave;
    }
}
