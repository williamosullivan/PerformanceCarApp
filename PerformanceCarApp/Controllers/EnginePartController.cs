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
    public class EnginePartController : Controller
    {
        private CarContext db = new CarContext();

        // GET: EnginePart
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var parts = from p in db.EngineParts select p;

            switch(sortOrder)
            {
                case "name_desc":
                    parts = parts.OrderByDescending(p => p.EnginePartName);
                    break;

                default:
                    parts = parts.OrderBy(p => p.EnginePartName);
                    break;

            }
            return View(db.EngineParts.ToList());
        }

        // GET: EnginePart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnginePart enginePart = db.EngineParts.Find(id);
            if (enginePart == null)
            {
                return HttpNotFound();
            }
            return View(enginePart);
        }

        // GET: EnginePart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnginePart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnginePartID,PartID,EnginePartHPGain,EnginePartName")] EnginePart enginePart)
        {
            if (ModelState.IsValid)
            {
                db.EngineParts.Add(enginePart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enginePart);
        }

        // GET: EnginePart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnginePart enginePart = db.EngineParts.Find(id);
            if (enginePart == null)
            {
                return HttpNotFound();
            }
            return View(enginePart);
        }

        // POST: EnginePart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnginePartID,PartID,EnginePartHPGain,EnginePartName")] EnginePart enginePart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enginePart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enginePart);
        }

        // GET: EnginePart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnginePart enginePart = db.EngineParts.Find(id);
            if (enginePart == null)
            {
                return HttpNotFound();
            }
            return View(enginePart);
        }

        // POST: EnginePart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnginePart enginePart = db.EngineParts.Find(id);
            db.EngineParts.Remove(enginePart);
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
