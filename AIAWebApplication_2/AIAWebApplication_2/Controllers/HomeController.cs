using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AIAWebApplication_2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Main", "Dashboard", null);
            }
            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.Where(u => u.ApplicationUserId == userId).First().Id;

            WelcomeViewModel vm = new WelcomeViewModel();
            vm.SavedQuotes = db.Quotes.Where(q => q.AIAUserId == aiaUserId && !q.Submitted).ToList();
            vm.SubmittedQuotes = db.Quotes.Where(q => q.AIAUserId == aiaUserId && q.Submitted).ToList();

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}