using AIARestApi;
using AIAUniversalApp.Shared.Helpers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace AIAUniversalApp.Controllers
{
    public class QuoteController : BaseController
    {
        public QuoteController() { }

        public QuoteController(ActiveQuoteViewModel aq)
        {
            this.activeQuoteViewModel = aq;
        }

        public QuoteController(long id)
        {
            Quote currentQuote = Helper.Get<Quote>(id);
            activeQuoteViewModel = Converter.convertQuoteToViewModel(currentQuote);
        }

        public void CalculateQuote()
        {
            throw new System.NotImplementedException();
        }

        public void Submit()
        {
            Quote submitQuote = pendingQuote();
            submitQuote.Submitted = true;
            Helper.Post<Quote>(submitQuote);
        }

        public void Save()
        {
            Quote submitQuote = pendingQuote();
            submitQuote.Submitted = false;
            Helper.Post<Quote>(submitQuote);
        }

        private Quote pendingQuote()
        {
            return Converter.convertViewModelToQuote(activeQuoteViewModel);
        }
    }
}
