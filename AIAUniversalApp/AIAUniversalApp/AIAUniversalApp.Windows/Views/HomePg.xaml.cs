using AIARestApi;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AIAUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePg : Page
    {
        private HomeController hc;
        public ObservableCollection<ActiveQuoteViewModel> lq;

        public HomePg()
        {
            this.InitializeComponent();
            hc = new HomeController();
            lq = hc.listQuoteViewModel.SavedQuotes;
            this.DataContext = hc.listQuoteViewModel;
            ListQuotes.ItemsSource = lq;
        }

        private void GetSavedQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = hc.listQuoteViewModel;
            lq = hc.listQuoteViewModel.SavedQuotes;
            ListQuotes.ItemsSource = lq;
        }

        private void GetSubmittedQuotesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = hc.listQuoteViewModel;
            lq = hc.listQuoteViewModel.SubmittedQuotes;
            ListQuotes.ItemsSource = lq;
        }



        private void ListQuotes_ItemClick(object sender, ItemClickEventArgs e)
        {
            long quoteId = ((ActiveQuoteViewModel)e.ClickedItem).Id;
            Frame.Navigate(typeof(QuotePg), quoteId);
        }
    }
}
