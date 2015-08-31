using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class WelcomeViewModel
    {
        public List<Quote> SavedQuotes { get; set; }
        public List<Quote> SubmittedQuotes { get; set; }
    }
}