using AIARestApi;
using AIAUniversalApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace AIAUniversalApp.ViewModels
{
    public class ListQuoteViewModel
    {
        public ListQuoteViewModel()
        {
            SubmittedQuotes = new ObservableCollection<ActiveQuoteViewModel>();
            SavedQuotes = new ObservableCollection<ActiveQuoteViewModel>(
                Helper.Get<Quote>().Select(x => Converter.convertQuoteToViewModel(x)).ToList<ActiveQuoteViewModel>());
        }

        public ObservableCollection<ActiveQuoteViewModel> SubmittedQuotes { get; set; }

        public ObservableCollection<ActiveQuoteViewModel> SavedQuotes { get; set; }
    }
}
