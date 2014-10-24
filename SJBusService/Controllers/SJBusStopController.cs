using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJBusService.Models;

namespace SJBusService.Controllers
{
    public class SJBusStopController : Controller
    {
        private BusServiceEntities db = new BusServiceEntities();

        //
        // GET: /SJBusStop/

        public ActionResult Index()
        {
            return View(db.busStops.ToList());
        }

        //
        // GET: /SJBusStop/Details/5

        public ActionResult Details(int id = 0)
        {
            busStop busstop = db.busStops.Find(id);
            if (busstop == null)
            {
                return HttpNotFound();
            }
            return View(busstop);
        }

        //
        // GET: /SJBusStop/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SJBusStop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Hashes busstop name
        public ActionResult Create(busStop busstop)
        {
            
            if (ModelState.IsValid)
            {
                int temp = 0;
                foreach (char item in busstop.location)
                    temp += Convert.ToInt32(item);

                busstop.locationHash = temp;
                db.busStops.Add(busstop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busstop);
        }

        //
        // GET: /SJBusStop/Edit/5

        public ActionResult Edit(int id = 0)
        {
            busStop busstop = db.busStops.Find(id);
            if (busstop == null)
            {
                return HttpNotFound();
            }
            return View(busstop);
        }

        //
        // POST: /SJBusStop/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(busStop busstop)
        {
            if (ModelState.IsValid)
            {
                int temp = 0;
                foreach (char item in busstop.location)
                    temp += Convert.ToInt32(item);
                busstop.locationHash = temp;
                db.Entry(busstop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busstop);
        }

        //
        // GET: /SJBusStop/Delete/5

        public ActionResult Delete(int id = 0)
        {
            busStop busstop = db.busStops.Find(id);
            if (busstop == null)
            {
                return HttpNotFound();
            }
            return View(busstop);
        }

        //
        // POST: /SJBusStop/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            busStop busstop = db.busStops.Find(id);
            db.busStops.Remove(busstop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}