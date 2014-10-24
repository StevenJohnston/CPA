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
    public class SJBusRouteController : Controller
    {
        private BusServiceEntities db = new BusServiceEntities();

        //
        // GET: /SJBusRoute/

        public ActionResult Index()
        {
            return View(db.busRoutes.ToList());
        }

        //
        // GET: /SJBusRoute/Details/5

        public ActionResult Details(string id = null)
        {
            busRoute busroute = db.busRoutes.Find(id);
            if (busroute == null)
            {
                return HttpNotFound();
            }
            return View(busroute);
        }

        //
        // GET: /SJBusRoute/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SJBusRoute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(busRoute busroute)
        {
            if (ModelState.IsValid)
            {
                db.busRoutes.Add(busroute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busroute);
        }

        //
        // GET: /SJBusRoute/Edit/5

        public ActionResult Edit(string id = null)
        {
            busRoute busroute = db.busRoutes.Find(id);
            if (busroute == null)
            {
                return HttpNotFound();
            }
            return View(busroute);
        }

        //
        // POST: /SJBusRoute/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(busRoute busroute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busroute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busroute);
        }

        //
        // GET: /SJBusRoute/Delete/5

        public ActionResult Delete(string id = null)
        {
            busRoute busroute = db.busRoutes.Find(id);
            if (busroute == null)
            {
                return HttpNotFound();
            }
            return View(busroute);
        }

        //
        // POST: /SJBusRoute/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            busRoute busroute = db.busRoutes.Find(id);
            db.busRoutes.Remove(busroute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private Int32 getHashed(string location)
        {
            return 7;
        }
    }
}