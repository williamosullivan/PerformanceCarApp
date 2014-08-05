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
    public class SuspensionController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Suspension
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var suspension = from s in db.Suspensions select s;

            switch(sortOrder)
            {
                case"name_desc":
                    suspension = suspension.OrderByDescending(s => s.SuspensionName);
                    break;

                default:
                    suspension = suspension.OrderBy(s => s.SuspensionName);
                    break;
            }

            return View(db.Suspensions.ToList());
        }

        // GET: Suspension/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspensions.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            return View(suspension);
        }

        // GET: Suspension/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suspension/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuspensionID,PartID,SuspensionDrop,SuspensionWeightSave,SuspensionName")] Suspension suspension)
        {
            if (ModelState.IsValid)
            {
                db.Suspensions.Add(suspension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspension);
        }

        // GET: Suspension/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspensions.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            return View(suspension);
        }

        // POST: Suspension/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuspensionID,PartID,SuspensionDrop,SuspensionWeightSave,SuspensionName")] Suspension suspension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspension);
        }

        // GET: Suspension/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspension suspension = db.Suspensions.Find(id);
            if (suspension == null)
            {
                return HttpNotFound();
            }
            return View(suspension);
        }

        // POST: Suspension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspension suspension = db.Suspensions.Find(id);
            db.Suspensions.Remove(suspension);
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
