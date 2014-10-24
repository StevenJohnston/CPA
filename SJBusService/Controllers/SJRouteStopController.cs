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
    public class SJRouteStopController : Controller
    {
        private BusServiceEntities db = new BusServiceEntities();

        //
        // GET: /SJRouteStop/
        /// <summary>
        /// Loads route stops from datbase where busroutecode = id from3rd parameter 
        /// adds cookie that is equal to id form 3rd parameter
        /// adds cookie that is equal to busname from query 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(string id = null)
        {
            Response.Cookies.Add(new HttpCookie("busCode", id));
            var routeschedules = db.routeStops.Where(r => r.busRoute.busRouteCode == id);
            var busNames = from p in db.routeStops where p.busRouteCode == id select p.busRoute;
            try
            {
                Response.Cookies.Add(new HttpCookie("busName", Convert.ToString(busNames.First().routeName)));
            }
            catch (Exception e) { }
            return View(routeschedules);
        }

        //
        // GET: /SJRouteStop/Details/5

        public ActionResult Details(int id = 0)
        {
            routeStop routestop = db.routeStops.Find(id);
            if (routestop == null)
            {
                return HttpNotFound();
            }
            return View(routestop);
        }

        //
        // GET: /SJRouteStop/Create

        public ActionResult Create()
        {
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName");
            ViewBag.busStopNumber = new SelectList(db.busStops, "busStopNumber", "location");
            return View();
        }

        //
        // POST: /SJRouteStop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //sets busrouteCode to busCode cookie values then saves rotestop todatabase
        public ActionResult Create(routeStop routestop)
        {
            if (ModelState.IsValid)
            {
                routestop.busRouteCode = Request.Cookies["busCode"].Value;
                db.routeStops.Add(routestop);
                db.SaveChanges();
                return RedirectToAction("Create", new { id = Request.Cookies["busCode"].Value });
            }

            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routestop.busRouteCode);
            ViewBag.busStopNumber = new SelectList(db.busStops, "busStopNumber", "location", routestop.busStopNumber);
            return View(routestop);
        }

        //
        // GET: /SJRouteStop/Edit/5
        
        public ActionResult Edit(int id = 0)
        {
            routeStop routestop = db.routeStops.Find(id);
            if (routestop == null)
            {
                return HttpNotFound();
            }
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routestop.busRouteCode);
            ViewBag.busStopNumber = new SelectList(db.busStops, "busStopNumber", "location", routestop.busStopNumber);
            return View(routestop);
        }

        //
        // POST: /SJRouteStop/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //savesedits from routestop
        public ActionResult Edit(routeStop routestop)
        {
            if (ModelState.IsValid)
            {
                routestop.busRouteCode = Request.Cookies["busCode"].Value;
                db.Entry(routestop).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", new { id = Request.Cookies["busCode"].Value });
            }
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routestop.busRouteCode);
            ViewBag.busStopNumber = new SelectList(db.busStops, "busStopNumber", "location", routestop.busStopNumber);
            return View(routestop);
        }

        //
        // GET: /SJRouteStop/Delete/5

        public ActionResult Delete(int id = 0)
        {
            routeStop routestop = db.routeStops.Find(id);
            if (routestop == null)
            {
                return HttpNotFound();
            }
            return View(routestop);
        }

        //
        // POST: /SJRouteStop/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routeStop routestop = db.routeStops.Find(id);
            db.routeStops.Remove(routestop);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = Request.Cookies["busCode"].Value });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}