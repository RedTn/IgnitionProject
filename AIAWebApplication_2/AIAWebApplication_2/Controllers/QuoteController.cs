using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AIAWebApplication_2.Helpers;

namespace AIAWebApplication_2.Controllers
{
    [Authorize(Roles = "Agent")]
    public class QuoteController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Begin()
        {
            Quote quote = new Quote();
            return View(quote);
        }

        [HttpPost]
        public ActionResult Begin(Quote model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var aiaUserId = db.AIAUsers.First(u => u.ApplicationUserId == userId).Id;
                model.AIAUserId = aiaUserId;
                db.Quotes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Create", "Driver", new { id = model.Id });
            }
            return View(model);
        }

        //// GET: Quote
        //public ActionResult AgentSearch(int? quoteId, string submitted,
        //    string startDate, string endDate)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var aiaUserId = db.AIAUsers.First(u => u.ApplicationUserId == userId).Id;
        //    //TODO: Comment this back out
        //    //var quotes = db.Quotes.Where(q => q.AIAUserId == aiaUserId).ToList();
        //    var quotes = db.Quotes.ToList();
        //    if (quoteId != null)
        //    {
        //        quotes = quotes.Where(q => q.Id == quoteId).ToList();
        //    }
        //    else
        //    {

        //    }

        //    AgentSearchViewModel vm = new AgentSearchViewModel();
        //    vm.Quotes = quotes;
        //    return View(vm);
        //}

        public ActionResult AgentSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgentSearch(AgentSearchModel model)
        {
            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.First(u => u.ApplicationUserId == userId).Id;
            var quotes = db.Quotes.Where(q => q.AIAUserId == aiaUserId).ToList();
            //var quotes = db.Quotes.ToList();
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
            if (model.Submitted != null)
            {
                quotes = quotes.Where(q => q.Submitted == model.Submitted).ToList();
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

        public ActionResult Summary(long id)
        {
            var drivers = db.Drivers.Where(d => d.QuoteId == id).ToList();
            var vehicles = db.Vehicles.Where(v => v.QuoteId == id).ToList();

            ViewBag.Drivers = drivers;
            ViewBag.Vehicles = vehicles;

            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.First(u => u.ApplicationUserId == userId).Id;
            Quote quote = new Quote();
            quote = db.Quotes.SingleOrDefault(d => d.Id == id && d.AIAUserId == aiaUserId && !d.Submitted);
            if (quote == null)
            {
                return View("Error");
            }
            QuoteCalculation qc = new QuoteCalculation();
            quote.Price = qc.calcQuote(quote, drivers, vehicles);
            db.Entry(quote).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.DriverCost = qc.driverCost();
            ViewBag.VehicleCost = qc.vehicleCost();

            return View(quote);
        }

        public ActionResult Submit(long id)
        {
            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.First(u => u.ApplicationUserId == userId).Id;
            Quote quote = db.Quotes.SingleOrDefault(d => d.Id == id && d.AIAUserId == aiaUserId && !d.Submitted);
            if (quote == null)
            {
                return View("Error");
            }
            quote.SubmissionTime = DateTime.Now;
            quote.Submitted = true;
            db.Entry(quote).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home", null);
        }
    }
}