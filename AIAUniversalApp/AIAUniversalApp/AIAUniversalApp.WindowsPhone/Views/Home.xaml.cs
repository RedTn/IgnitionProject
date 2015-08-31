using AIARestApi;
using AIAUniversalApp.Controllers;
using AIAUniversalApp.Shared.Helpers;
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
    public sealed partial class Home : Page
    {
        
        HomeController hc;
        ObservableCollection<ActiveQuoteViewModel> lq;
        private ActiveQuoteViewModel activeQuoteViewModel;

        public Home()
        {
            this.InitializeComponent();
            hc = new HomeController();
            this.DataContext = hc.listQuoteViewModel;
            lq = hc.listQuoteViewModel.SavedQuotes;

            ListQuotes.ItemsSource = lq;

        }

        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = hc.listQuoteViewModel;
            lq = hc.listQuoteViewModel.SavedQuotes;
            ListQuotes.ItemsSource = lq;
        }

        private void Submitted_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = hc.listQuoteViewModel;
            lq = hc.listQuoteViewModel.SubmittedQuotes;
            ListQuotes.ItemsSource = lq;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            long quoteId = 4; // need to add a name to the row so I can access the activeQuoteViewModel
            Frame.Navigate(typeof(QuoteSummary), quoteId);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void Quote_ItemClick(object sender, ItemClickEventArgs e)
        {
            long quoteId = ((ActiveQuoteViewModel)e.ClickedItem).Id;
            Frame.Navigate(typeof(QuoteSummary), quoteId);
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
           //activeQuoteViewModel.
            Frame.Navigate(typeof(QuoteSummary));
        }

    }
}
