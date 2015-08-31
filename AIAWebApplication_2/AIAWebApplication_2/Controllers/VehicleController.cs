using AIAWebApplication_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AIAWebApplication_2.Controllers
{
    [Authorize(Roles = "Agent")]
    public class VehicleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicle/Create
        public ActionResult Create(long id)
        {
            var userId = User.Identity.GetUserId();
            var aiaUserId = db.AIAUsers.Where(u => u.ApplicationUserId == userId).First().Id;

            var check = db.Quotes.Where(q => q.AIAUserId == aiaUserId && q.Id == id && !q.Submitted).SingleOrDefault();
            if (check == null)
            {
                return View("Error");
            }

            var vehicles = db.Vehicles.Where(v => v.QuoteId == id).ToList();
            ViewBag.Vehicles = vehicles;

            var drivers = db.Drivers.Where(d => d.QuoteId == id).ToList();
            ViewBag.Drivers = new SelectList(drivers, "Id", "FirstName");
            ViewBag.DriversToTable = drivers;

            Vehicle vehicle = new Vehicle();
            vehicle.QuoteId = id;
            return View(vehicle);
        }

        // POST: Vehicle/Create
        [HttpPost]
        public ActionResult Create(Vehicle model, long id)
        {
            if (ModelState.IsValid)
            {
                //TODO: Make sure cant submit to submitted quote, Validate now
                //TODO: Make sure only CURRENT User and modify HIS OWN quote, Validate now
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
                db.Vehicles.Add(model);
                db.SaveChanges();
                return RedirectToAction("Create", "Vehicle", new { id = id });
            }
            return View(model);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehicle/Edit/5
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

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehicle/Delete/5
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
