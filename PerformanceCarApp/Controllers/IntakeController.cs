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
    public class IntakeController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Intake
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm=String.IsNullOrEmpty(sortOrder)?"name_desc": "";
            var intake=from i in db.Intakes select i;

            switch(sortOrder)
            {
                case "name_desc":
                    intake=intake.OrderByDescending(i=>i.IntakeName);
                    break;

                default:
                    intake=intake.OrderBy(i=>i.IntakeName);
                    break;
            }

            return View(db.Intakes.ToList());
        }

        // GET: Intake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // GET: Intake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IntakeID,PartID,IntakeHPGain,IntakeName")] Intake intake)
        {
            if (ModelState.IsValid)
            {
                db.Intakes.Add(intake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(intake);
        }

        // GET: Intake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // POST: Intake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IntakeID,PartID,IntakeHPGain,IntakeName")] Intake intake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intake);
        }

        // GET: Intake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // POST: Intake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intake intake = db.Intakes.Find(id);
            db.Intakes.Remove(intake);
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
