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
using System.IO;

namespace PerformanceCarApp.Controllers
{
    public class UserController : Controller
    {
        private CarContext db = new CarContext();

        // GET: User
        public ActionResult Index(Car car, User member)
        {
            car = (Car)TempData["Car"];
            member = (User)TempData["Member"];
            ViewBag.UserID = member.UserID;
            ViewBag.URL = member.ImageURL;
            return View(member);
        }
        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create(User member)
        {
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make");
            return View(member);
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,CarID,UserName,UserEmail,UserBirthday,Gender,Horsepower,QuarterMile, ImageURL")] User user, Car car)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make", user.CarID);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            User person = (from u in db.Users
                           where u.UserID == id
                           select u).First();
            (TempData["Member"]) = person;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "Make");
            Car car = (from c in db.Cars
                       where c.CarID == id
                       select c).First();
            return View(person);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,CarID,UserName,UserEmail,UserBirthday,Gender,Horsepower,QuarterMile, ImageURL")] User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", user);
            }

            ViewBag.UserID = new SelectList(db.Cars, "CarID", "CarMake", user.CarID);
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                file.SaveAs(path);
                User user = (User)(TempData["Member"]);
                user.ImageURL = path;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Upload");
            }
        }

        public ActionResult Chat()
        {
            return View();
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
