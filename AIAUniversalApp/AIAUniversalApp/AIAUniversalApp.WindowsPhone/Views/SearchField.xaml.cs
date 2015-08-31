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
    public sealed partial class SearchField : UserControl
    {
        public SearchField()
        {
            this.InitializeComponent();
        }

        private void Item1_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Quote Number";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item2_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "First Name";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item3_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Last Name";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item4_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "State";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item5_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Phone Number";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item6_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Zip Code";
            tBox.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item7_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Date";
            tBox.Visibility = Visibility.Collapsed;
            datePicker.Visibility = Visibility.Visible;
            quoteP.Visibility = Visibility.Collapsed;
        }

        private void Item8_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Quote Type";
            tBox.Visibility = Visibility.Collapsed;
            datePicker.Visibility = Visibility.Collapsed;
            quoteP.Visibility = Visibility.Visible;
        }

    }
}
