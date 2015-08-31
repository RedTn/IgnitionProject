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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AIAUniversalApp.Views
{
    public sealed partial class TopNavigationBar : UserControl
    {
        private BaseController baseController;
        public ActiveQuoteViewModel activeQuoteViewModel;

        public TopNavigationBar()
        {
            this.InitializeComponent();
            baseController = new BaseController();
            activeQuoteViewModel = baseController.activeQuoteViewModel;
        }

    }
}
