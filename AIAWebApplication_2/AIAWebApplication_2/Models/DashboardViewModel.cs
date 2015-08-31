using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace AIAWebApplication_2.Models
{
    public class DashboardViewModel
    {
        public int QuotesThisMonth { get; set; }
	    public decimal CompanyTotal { get; set; }
	    public List<Quote> RecentQuotesList { get; set; }
	    public List<AIAUser> RecentAiaUsersList { get; set; }
		public List<Quote> TopFiveQuoteList { get; set; }
	    public List<AIAUser> TopFiveAgentList { get; set; }
	    public List<AIAUser> PendingAiaUsersList { get; set; }
	    public List<AIAUser> AllAgentsList { get; set; }
	    public List<decimal> AgentTotalsList { get; set; }
    }
}