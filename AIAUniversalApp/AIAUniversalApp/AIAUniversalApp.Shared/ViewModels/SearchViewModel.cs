using System;
using System.Collections.Generic;
using System.Text;

namespace AIAUniversalApp.ViewModels
{
    public class SearchViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public State State { get; set; }
        public QuoteStatus Submitted { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
    }
}
