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
using Windows.UI;
using AIAUniversalApp.Controllers;
using AIAUniversalApp.ViewModels;
using AIAUniversalApp.Shared.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AIAUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        private int count = 1;
        private int count2 = 1;
        private int count3 = 1;
        private int count4 = 1;
        private int count5 = 1;
        private int count6 = 1;
        private int count7 = 1;
        private SearchController searchController;
        private SearchViewModel searchViewModel;

        public SearchPage()
        {
            this.InitializeComponent();
            searchController = new SearchController();
            searchViewModel = searchController.SearchViewModel;
            searchViewModel.DateStart = new DateTime(2015, 01, 01);
            searchViewModel.DateEnd = new DateTime(2015, 12, 31);
            this.DataContext = searchViewModel;
            StateList.ItemsSource = Enum.GetValues(typeof(State));
            QuoteStatusList.ItemsSource = Enum.GetValues(typeof(QuoteStatus));
        }

        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        public static Brush ColorToBrush(string color) // color = "#E7E44D"
        {
            color = color.Replace("#", "");
             return new SolidColorBrush(ColorHelper.FromArgb(255,
                    byte.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber)));
           
        }
        
        private void First_Click(object sender, RoutedEventArgs e)
        {
            count++;
            if (count % 2 == 0) {
                string color = "#F24545";
                First.BorderBrush = ColorToBrush(color);
                First.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                First.BorderBrush = ColorToBrush(color2);
                First.Foreground = ColorToBrush(color2);
            }
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            count2++;
            if (count2 % 2 == 0)
            {
                string color = "#F24545";
                Last.BorderBrush = ColorToBrush(color);
                Last.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                Last.BorderBrush = ColorToBrush(color2);
                Last.Foreground = ColorToBrush(color2);
            }
        }

        private void State_Click(object sender, RoutedEventArgs e)
        {
            count3++;
            if (count3 % 2 == 0)
            {
                string color = "#F24545";
                StateB.BorderBrush = ColorToBrush(color);
                StateB.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                StateB.BorderBrush = ColorToBrush(color2);
                StateB.Foreground = ColorToBrush(color2);
            }
        }
        private void StateSelection_Click(ListPickerFlyout sender, ItemsPickedEventArgs e)
        {
            StateButton.Content = Enum.GetName(typeof(State), searchViewModel.State);
        }

        private void QuoteStatusSelection_Click(ListPickerFlyout sender, ItemsPickedEventArgs e)
        {
            QuoteStatusButton.Content = Enum.GetName(typeof(QuoteStatus), searchViewModel.Submitted);
        }

        private void Phone_Click(object sender, RoutedEventArgs e)
        {
            count4++;
            if (count4 % 2 == 0)
            {
                string color = "#F24545";
                Phone.BorderBrush = ColorToBrush(color);
                Phone.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                Phone.BorderBrush = ColorToBrush(color2);
                Phone.Foreground = ColorToBrush(color2);
            }
        }

     

        private void Date_Click(object sender, RoutedEventArgs e)
        {
            count6++;
            if (count6 % 2 == 0)
            {
                string color = "#F24545";
                Date.BorderBrush = ColorToBrush(color);
                Date.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                Date.BorderBrush = ColorToBrush(color2);
                Date.Foreground = ColorToBrush(color2);
            }
        }

        private void Quote_Click(object sender, RoutedEventArgs e)
        {
            count7++;
            if (count7 % 2 == 0)
            {
                string color = "#F24545";
                Quote.BorderBrush = ColorToBrush(color);
                Quote.Foreground = ColorToBrush(color);
            }
            else
            {
                string color2 = "#000000";
                Quote.BorderBrush = ColorToBrush(color2);
                Quote.Foreground = ColorToBrush(color2);
            }
        }





        //private void Add_Click(object sender, RoutedEventArgs e)
        
        private void Search_Click(object sender, RoutedEventArgs e)
        {
           //List<ActiveQuoteViewModel> ans = Helper.GetSearch("ByFirstName", searchViewModel.FirstName).Select(x =>
           //   Converter.convertQuoteToViewModel(x)).ToList<ActiveQuoteViewModel>();

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
           Frame.Navigate(typeof(SearchResults), ans);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
