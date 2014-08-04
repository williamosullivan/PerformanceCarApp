using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCFinalProject.DAL;
using GCFinalProject.Models;

namespace PerformanceCarApp.Controllers
{
    public class BrakesController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Brakes
        public ActionResult Index()
        {
            return View(db.Brakes.ToList());
        }

        // GET: Brakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // GET: Brakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrakeID,PartID,BrakeWeightSave,BrakeName")] Brakes brakes)
        {
            if (ModelState.IsValid)
            {
                db.Brakes.Add(brakes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brakes);
        }

        // GET: Brakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // POST: Brakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrakeID,PartID,BrakeWeightSave,BrakeName")] Brakes brakes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brakes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brakes);
        }

        // GET: Brakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brakes brakes = db.Brakes.Find(id);
            if (brakes == null)
            {
                return HttpNotFound();
            }
            return View(brakes);
        }

        // POST: Brakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brakes brakes = db.Brakes.Find(id);
            db.Brakes.Remove(brakes);
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
