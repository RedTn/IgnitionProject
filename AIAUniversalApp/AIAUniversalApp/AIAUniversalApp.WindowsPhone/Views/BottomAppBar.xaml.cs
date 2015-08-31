using AIAUniversalApp.Controllers;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AIAUniversalApp.Views
{
    public sealed partial class BottomAppBar : UserControl
    {
        private BaseController baseController;
        public ActiveQuoteViewModel activeQuoteViewModel;
        public BottomAppBar()
        {
            this.InitializeComponent();
            baseController = new BaseController();
            activeQuoteViewModel = baseController.activeQuoteViewModel;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var currentPage = Window.Current.Content;
            ((Frame)currentPage).Navigate(typeof(Home), null);
        }

        private void Add_Quote_Click(object sender, RoutedEventArgs e)
        {
            var currentPage = Window.Current.Content;
            activeQuoteViewModel = new ActiveQuoteViewModel(true);
            ((Frame)currentPage).Navigate(typeof(DriverInfo), activeQuoteViewModel);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var currentPage = Window.Current.Content;
            ((Frame)currentPage).Navigate(typeof(SearchPage), null);
        }
    }
}
