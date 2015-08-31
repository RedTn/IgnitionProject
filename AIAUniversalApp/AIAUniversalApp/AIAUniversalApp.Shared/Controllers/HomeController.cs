using AIARestApi;
using AIAUniversalApp.Shared.Helpers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIAUniversalApp.Controllers
{
    public class HomeController: BaseController
    {

        public ListQuoteViewModel listQuoteViewModel { get; set; }

        public HomeController()
        {
            listQuoteViewModel = new ListQuoteViewModel();
        }

        public void GetQuotesSubmitted()
        {
            //long id = 1;
            //List<Quote> quotes = Helper.Get<AIAUser>(id).Quotes as List<Quote>;
            //List<Quote> newQuoteList = new List<Quote>();
            //foreach (var quote in quotes)
            //{
            //    if (quote.Submitted)
            //    {
            //        newQuoteList.Add(quote);
            //    }
            //}
            //listQuoteViewModel.SubmittedQuotes = newQuoteList;
        }

        public void GetQuotesSaved()
        {
            //long id = 1;
            //List<Quote> quotes = Helper.Get<AIAUser>(id).Quotes as List<Quote>;
            //List<Quote> newQuoteList = new List<Quote>();
            //foreach (var quote in quotes)
            //{
            //    if (!quote.Submitted)
            //    {
            //        newQuoteList.Add(quote);
            //    }
            //}
            //listQuoteViewModel.SavedQuotes = newQuoteList;
        }
    }
}
