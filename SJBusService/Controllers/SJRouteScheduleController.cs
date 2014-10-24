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
    public class SJRouteScheduleController : Controller
    {
        private BusServiceEntities db = new BusServiceEntities();

        //
        // GET: /SJRouteSchedule/
        /// <summary>
        /// Gets the routSchedules from the database where bus code is equal to the one they clicked and orders them by the time they start
        /// adds a cookie that is saves the bus name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(string id = null)
        {
            
            Response.Cookies.Add(new HttpCookie("busCode",id));
            var routeschedules = db.routeSchedules.Where(r => r.busRoute.busRouteCode == id ).OrderBy(r=>r.startTime);
            var busNames = from p in db.routeSchedules where p.busRouteCode == id select p.busRoute;
            try
            {

                Response.Cookies.Add(new HttpCookie("busName", Convert.ToString(busNames.First().routeName)));
            }
            catch (Exception e) { }
            return View(routeschedules);
        }

        //
        // GET: /SJRouteSchedule/Details/5

        public ActionResult Details(int id = 0)
        {
            routeSchedule routeschedule = db.routeSchedules.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            return View(routeschedule);
        }

        //
        // GET: /SJRouteSchedule/Create

        public ActionResult Create(string id = null)
        {
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName");
            return View();
        }

        //
        // POST: /SJRouteSchedule/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        //makes busroutcode equal to cookie data then adds routeto database
        public ActionResult Create(routeSchedule routeschedule, string id = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    routeschedule.busRouteCode = Request.Cookies["busCode"].Value;
                    db.routeSchedules.Add(routeschedule);
                    ViewBag.sel = new SelectList(db.busRoutes);
                    db.SaveChanges();
                    View(routeschedule);
                    return RedirectToAction("Create", new { id = routeschedule.busRouteCode });
                }
                catch (Exception e)
                { 
                    
                }
            }
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routeschedule.busRouteCode);
            return View(routeschedule);
        }

        //
        // GET: /SJRouteSchedule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            routeSchedule routeschedule = db.routeSchedules.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routeschedule.busRouteCode);
            return View(routeschedule);
        }

        //
        // POST: /SJRouteSchedule/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //
        public ActionResult Edit(routeSchedule routeschedule)
        {
            try
            {
                routeschedule.busRouteCode = Request.Cookies["busCode"].Value;
                if (ModelState.IsValid)
                {
                    db.Entry(routeschedule).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = Request.Cookies["busCode"].Value });
                }
                ViewBag.busRouteCode = new SelectList(db.busRoutes, "busRouteCode", "routeName", routeschedule.busRouteCode);
                return View(routeschedule);
            }
            catch (Exception e)
            { }
            return View(routeschedule);
        }

        //
        // GET: /SJRouteSchedule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            routeSchedule routeschedule = db.routeSchedules.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            return View(routeschedule);
        }

        //
        // POST: /SJRouteSchedule/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //Deletes record from database
        public ActionResult DeleteConfirmed(int id)
        {
            routeSchedule routeschedule = db.routeSchedules.Find(id);
            db.routeSchedules.Remove(routeschedule);
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