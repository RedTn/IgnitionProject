using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AIAWebApplication_2.Controllers
{
    [Authorize(Roles = "Agent")]
    public class DriverController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Driver
        public ActionResult Index()
        {
            return View();
        }

        // GET: Driver/Details/5
        public ActionResult Details(long id) {
	        var model = db.Drivers.Where(p => p.Id == id).SingleOrDefault();
            return View(model);
        }

        // GET: Driver/Create
        public ActionResult Create(long id)
        {
            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.Where(u => u.ApplicationUserId == userId).First().Id;

            var check = db.Quotes.Where(q => q.AIAUserId == aiaUserId && q.Id == id && !q.Submitted).SingleOrDefault();
            if (check == null)
            {
                return View("Error");
            }

            Driver model = new Driver();
            model.QuoteId = id;
            var drivers = db.Drivers.Where(d => d.QuoteId == id).ToList();
            ViewBag.Drivers = drivers;
            return View(model);
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(Driver model, long id)
        {
            //TODO: Make sure cant submit to submitted quote, Validate
            //TODO: Make sure only CURRENT User and modify HIS OWN quote, Validate
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var aiaUserId = db.AIAUsers.Where(u => u.ApplicationUserId == userId).First().Id;
                Quote check = db.Quotes.Where(d => d.Id == id && d.AIAUserId == aiaUserId && !d.Submitted).SingleOrDefault();
                if (check == null)
                {
                    return View("Error");
                }
                if (check.Submitted)
                {
                    return View("Error");
                }
                model.QuoteId = id;
                db.Drivers.Add(model);
                db.SaveChanges();
                return RedirectToAction("Create", "Driver", new { id = model.QuoteId });
            }
            return View(model);
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
