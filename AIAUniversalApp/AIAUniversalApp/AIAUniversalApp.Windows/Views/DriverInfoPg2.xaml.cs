﻿using System;
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
    public sealed partial class DriverInfoPg2 : Page
    {
        public DriverInfoPg2()
        {
            this.InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DriverInfoPg3), null);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DriverInfoPg1), null);

        }
    }
}
