using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PerformanceCarApp.DAL;
using PerformanceCarApp.Models;

namespace PerformanceCarApp.Controllers
{
    public class ExhaustController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Exhaust
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var exhausts = from e in db.Exhausts select e;

            switch(sortOrder)
            {
                case "name_desc":
                    exhausts = exhausts.OrderByDescending(e => e.ExhaustName);
                    break;

                default:
                    exhausts = exhausts.OrderBy(e => e.ExhaustName);
                    break;
            }
            return View(db.Exhausts.ToList());
        }

        // GET: Exhaust/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhaust exhaust = db.Exhausts.Find(id);
            if (exhaust == null)
            {
                return HttpNotFound();
            }
            return View(exhaust);
        }

        // GET: Exhaust/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exhaust/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExhaustID,PartID,ExhaustHPGain,ExhaustName")] Exhaust exhaust)
        {
            if (ModelState.IsValid)
            {
                db.Exhausts.Add(exhaust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhaust);
        }

        // GET: Exhaust/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhaust exhaust = db.Exhausts.Find(id);
            if (exhaust == null)
            {
                return HttpNotFound();
            }
            return View(exhaust);
        }

        // POST: Exhaust/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExhaustID,PartID,ExhaustHPGain,ExhaustName")] Exhaust exhaust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhaust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhaust);
        }

        // GET: Exhaust/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhaust exhaust = db.Exhausts.Find(id);
            if (exhaust == null)
            {
                return HttpNotFound();
            }
            return View(exhaust);
        }

        // POST: Exhaust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exhaust exhaust = db.Exhausts.Find(id);
            db.Exhausts.Remove(exhaust);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
