using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AIAWebApplication_2.Controllers {
	[Authorize(Roles = "Manager")]
	public class DashboardController : Controller {
		ApplicationDbContext db = new ApplicationDbContext();
		// GET: Dashboard
		public ActionResult Main() {
			DashboardViewModel vm = new DashboardViewModel();

			DateTime now = DateTime.Now;

			int quotes = db.Quotes.Count(q => q.Price > 0);

			var recentQuoteQuery = from q in db.Quotes
								   where q.SubmissionTime.Value.Month == now.Month
								   orderby q.SubmissionTime.Value descending
								   select q;

			List<Quote> recentQuotes = recentQuoteQuery.ToList();

			var recentAgentQuery = from agent in db.AIAUsers
								   from q in recentQuoteQuery
								   where agent.Id == q.AIAUserId
								   orderby q.SubmissionTime.Value descending
								   select agent;

			List<AIAUser> recentAgents = recentAgentQuery.ToList();

			var pendingAgents = from q in db.AIAUsers
								where q.CanUseSystem == 0
								orderby q.Id descending
								select q;

			List<AIAUser> pendingAiaUsers = pendingAgents.ToList();

			//var userRoles = from q in db.AIAUsers
			//	join roles in db.AspNetUserRoles on roles. equals EXPR2
			//TODO: GET THE USER ROLES FROM EACH USER IN THE DATABASE!

			var topFiveQuery = (from q in recentQuoteQuery
								orderby q.Price descending 
				select q).Take(5);

			var topFiveAgentQuery = (from agent in db.AIAUsers
				from q in topFiveQuery
				where agent.Id == q.AIAUserId
				orderby q.Price descending
				select agent).Take(5);

			List<AIAUser> topFiveAgents = topFiveAgentQuery.ToList();

			List<Quote> topQuotes = topFiveQuery.ToList();

			List<decimal> userTotal = new List<decimal>();

			foreach (var quote in db.Quotes) {
				decimal total = new decimal();
				total += quote.Price;
				userTotal.Add(total);
			}

			decimal agentsRevenueTotal = new decimal();

			foreach (var item in recentQuotes) {
				agentsRevenueTotal += item.Price;
			}

			vm.TopFiveAgentList = topFiveAgents;
			vm.CompanyTotal = agentsRevenueTotal;
			vm.TopFiveQuoteList = topQuotes;
			vm.AgentTotalsList = userTotal;
			vm.RecentAiaUsersList = recentAgents;
			vm.PendingAiaUsersList = pendingAiaUsers;
			vm.RecentQuotesList = recentQuotes;
			vm.QuotesThisMonth = quotes;

			return View(vm);
		}

		// GET: AgentManagerList
		public ActionResult AgentManagerList() {
			DashboardViewModel vm = new DashboardViewModel();
			var allUsersQquery = from user in db.AIAUsers
								 orderby user.Id
								 select user;

			List<AIAUser> allUsers = allUsersQquery.ToList();

			vm.AllAgentsList = allUsers;
			return View(vm);
		}

		// GET: Search
		[HttpGet]
		public ActionResult ManagerSearch(int? quoteId, string firstName, string lastName) {
			ManagerSearchViewModel vm = new ManagerSearchViewModel();
			var quotes = db.Quotes.Where(q => q.Submitted).ToList();
			if (quoteId != null) {
				quotes = quotes.Where(q => q.Id == quoteId).ToList();
			}
			else {
				if (!String.IsNullOrEmpty(firstName)) {
					quotes = quotes.Where(q => q.CustomerFirstName.StartsWith(firstName)).ToList();
				}
				if (!String.IsNullOrEmpty(lastName)) {
					quotes = quotes.Where(q => q.CustomerLastName.StartsWith(lastName)).ToList();
				}
			}

			vm.Quotes = quotes;
			return View(vm);
		}

		//[HttpPost]
		//public ActionResult ManagerSearch(SearchCriteria[] criteriaList)
		//{

		//    return View();
		//}

		[HttpPost]
		public ActionResult UpdateUser(AIAUser model) {
			var user = db.AIAUsers.SingleOrDefault(u => u.Id == model.Id);
			if (user == null) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			user.CanUseSystem = model.CanUseSystem;
			db.Entry(user).State = EntityState.Modified;
			db.SaveChanges();
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

        [HttpPost]
        public ActionResult ManagerSearch(ManagerSearchModel model)
        {
            var quotes = db.Quotes.Where(q => q.Submitted).ToList();
            if (model.Id != null)
            {
                quotes = quotes.Where(q => q.Id == model.Id).ToList();
            }
            if (!String.IsNullOrEmpty(model.CustomerFirstName))
            {
                quotes = quotes.Where(q => q.CustomerFirstName.StartsWith(model.CustomerFirstName)).ToList();
            }
            if (!String.IsNullOrEmpty(model.CustomerLastName))
            {
                quotes = quotes.Where(q => q.CustomerLastName.StartsWith(model.CustomerLastName)).ToList();
            }
            if (!String.IsNullOrEmpty(model.PhoneNumber))
            {
                quotes = quotes.Where(q => q.CustomerPhone.Contains(model.PhoneNumber)).ToList();
            }
            if (!String.IsNullOrEmpty(model.State))
            {
                quotes = quotes.Where(q => q.State == model.State).ToList();
            }
            if (model.Skip != null && model.Take != null)
            {
                //return Json(quotes.Skip(model.Skip.Value).Take(model.Take.Value));
                return Json(quotes.Select(q => new
                {
                    Id = q.Id,
                    AIAUserId = q.AIAUserId,
                    Price = q.Price,
                    Submitted = q.Submitted,
                    SubmissionTime = q.SubmissionTime,
                    State = q.State,
                    MovingViolation = q.MovingViolation,
                    PreviousCarrier = q.PreviousCarrier,
                    ClaimInLastFive = q.ClaimInLastFive,
                    ForceMultiDiscount = q.ForceMultiDiscount,
                    CustomerFirstName = q.CustomerFirstName,
                    CustomerLastName = q.CustomerLastName,
                    CustomerAddress = q.CustomerAddress,
                    CustomerPhone = q.CustomerPhone,
                    CustomerSsn = q.CustomerSsn,
                    CustomerDob = q.CustomerDob
                })
                .Skip(model.Skip.Value).Take(model.Take.Value));
            }
            if (model.Skip != null && model.Take == null)
            {
                //return Json(quotes.Skip(model.Skip.Value));
                return Json(quotes.Select(q => new
                {
                    Id = q.Id,
                    AIAUserId = q.AIAUserId,
                    Price = q.Price,
                    Submitted = q.Submitted,
                    SubmissionTime = q.SubmissionTime,
                    State = q.State,
                    MovingViolation = q.MovingViolation,
                    PreviousCarrier = q.PreviousCarrier,
                    ClaimInLastFive = q.ClaimInLastFive,
                    ForceMultiDiscount = q.ForceMultiDiscount,
                    CustomerFirstName = q.CustomerFirstName,
                    CustomerLastName = q.CustomerLastName,
                    CustomerAddress = q.CustomerAddress,
                    CustomerPhone = q.CustomerPhone,
                    CustomerSsn = q.CustomerSsn,
                    CustomerDob = q.CustomerDob
                }).Skip(model.Skip.Value));
            }
            if (model.Skip == null && model.Take != null)
            {
                //return Json(quotes.Take(model.Take.Value));
                return Json(quotes.Select(q => new
                {
                    Id = q.Id,
                    AIAUserId = q.AIAUserId,
                    Price = q.Price,
                    Submitted = q.Submitted,
                    SubmissionTime = q.SubmissionTime,
                    State = q.State,
                    MovingViolation = q.MovingViolation,
                    PreviousCarrier = q.PreviousCarrier,
                    ClaimInLastFive = q.ClaimInLastFive,
                    ForceMultiDiscount = q.ForceMultiDiscount,
                    CustomerFirstName = q.CustomerFirstName,
                    CustomerLastName = q.CustomerLastName,
                    CustomerAddress = q.CustomerAddress,
                    CustomerPhone = q.CustomerPhone,
                    CustomerSsn = q.CustomerSsn,
                    CustomerDob = q.CustomerDob
                })
                .Take(model.Take.Value));
            }
            else
            {
                //return Json(quotes);
                return Json(quotes.Select(q => new
                {
                    Id = q.Id,
                    AIAUserId = q.AIAUserId,
                    Price = q.Price,
                    Submitted = q.Submitted,
                    SubmissionTime = q.SubmissionTime,
                    State = q.State,
                    MovingViolation = q.MovingViolation,
                    PreviousCarrier = q.PreviousCarrier,
                    ClaimInLastFive = q.ClaimInLastFive,
                    ForceMultiDiscount = q.ForceMultiDiscount,
                    CustomerFirstName = q.CustomerFirstName,
                    CustomerLastName = q.CustomerLastName,
                    CustomerAddress = q.CustomerAddress,
                    CustomerPhone = q.CustomerPhone,
                    CustomerSsn = q.CustomerSsn,
                    CustomerDob = q.CustomerDob
                }));
            }
        }

	}
}