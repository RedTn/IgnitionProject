using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class ManagerSearchViewModel
    {
        public List<Quote> Quotes { get; set; }
		public List<Quote> SavedQuotes { get; set; }
    }
}