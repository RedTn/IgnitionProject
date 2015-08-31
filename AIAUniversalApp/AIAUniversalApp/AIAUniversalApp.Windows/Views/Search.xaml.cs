using AIARestApi;
using AIAUniversalApp.Controllers;
using AIAUniversalApp.Shared.Helpers;
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
    public sealed partial class Search : Page
    {
        private SearchController searchController;
        public SearchViewModel searchViewModel;

        public Search()
        {
            this.InitializeComponent();
            searchController = new SearchController();
            searchViewModel = searchController.SearchViewModel;
            searchViewModel.DateStart = new DateTime(2015, 01, 01);
            searchViewModel.DateEnd = new DateTime(2015, 12, 31);
            this.DataContext = searchController.SearchViewModel;
            StateList.ItemsSource = Enum.GetValues(typeof(State));
            QuoteStatusList.ItemsSource = Enum.GetValues(typeof(QuoteStatus));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //List<ActiveQuoteViewModel> ans = Helper.GetSearch("ByFirstName", searchViewModel.FirstName).Select(x =>
            //    Converter.convertQuoteToViewModel(x)).ToList<ActiveQuoteViewModel>();
            Dictionary<string, string> queries = new Dictionary<string, string>();

            if (searchViewModel.Id != null)
            {
                queries.Add("Id", searchViewModel.Id);
            }
            if (searchViewModel.FirstName != null)
            {
                queries.Add("FirstName", searchViewModel.FirstName);
            }
            if (searchViewModel.LastName != null)
            {
                queries.Add("LastName", searchViewModel.LastName);
            }
            if (searchViewModel.DateStart != null)
            {
                queries.Add("DateStart", searchViewModel.DateStart.DateTime.ToString());
            }
            if (searchViewModel.DateEnd != null)
            {
                queries.Add("DateEnd", searchViewModel.DateEnd.DateTime.ToString());
            }
            if (searchViewModel.State != State.None)
            {
                queries.Add("state", Enum.GetName(typeof(State), searchViewModel.State));
            }
            if (searchViewModel.Submitted != QuoteStatus.None)
            {
                bool isSubmitted;
                if (Enum.GetName(typeof(QuoteStatus), searchViewModel.Submitted).Equals("Saved"))
                {
                    isSubmitted = false;
                }
                else
                {
                    isSubmitted = true;
                }
                queries.Add("submitted", isSubmitted.ToString());
            }
            if (searchViewModel.Phone != null)
            {
                queries.Add("phone", searchViewModel.Phone);
            }
            if (searchViewModel.ZipCode != null)
            {
                queries.Add("zip", searchViewModel.ZipCode);
            }

            List<ActiveQuoteViewModel> ans = Helper.GetMultipleSearch(queries).Select(x =>
               Converter.convertQuoteToViewModel(x)).ToList<ActiveQuoteViewModel>();
            Frame.Navigate(typeof(Search_Results), ans);
            //Frame.Navigate(typeof(Search_Results), Helper.GetSearch("ByLastName", searchViewModel.LastName));
            
        }
    }
}
