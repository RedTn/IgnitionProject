using AIAUniversalApp.Controllers;
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
    public sealed partial class QuotePg : Page
    {
        private QuoteController qc;
        private ActiveQuoteViewModel activeQuoteViewModel;

        public QuotePg()
        {
            this.InitializeComponent();
            ((TextBlock)QuoteTopNav.FindName("QuoteTopNavTextBlock")).FontWeight = FontWeights.Bold;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            activeQuoteViewModel = e.Parameter as ActiveQuoteViewModel;
            qc = new QuoteController(activeQuoteViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is long)
            {
                qc = new QuoteController((long)e.Parameter);
            }
        }
    }
}
