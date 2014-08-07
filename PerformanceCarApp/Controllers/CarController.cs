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
    public class CarController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Car
        public ViewResult Index(string sortOrder, string searchString)
        {
            PopulateCarDropDown();
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MakeSortParm = sortOrder == "Make" ? "make_desc" : "Make";
            var cars = from c in db.Cars select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.Model.ToUpper().Contains(searchString.ToUpper())
                || c.Make.ToUpper().Contains(searchString.ToUpper()));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    cars = cars.OrderByDescending(c => c.Model);
                    break;
                case "Make":
                    cars = cars.OrderBy(c => c.Make);
                    break;
                case "make_desc":
                    cars = cars.OrderByDescending(c => c.Make);
                    break;
                default:
                    cars = cars.OrderBy(c => c.Model);
                    break;
            }
            return View(cars.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,Make,Model,Generation,Drivetrain,BodyStyle,BaseHorsepower,EngineSize,Trim")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Car/Edit/5
        
        public ActionResult Edit(int? id)
        {
            PopulateBrakesDropDown(id);
            PopulateEnginePartDropDown(id);
            PopulateExhaustDropDown(id);
            PopulateIntakeDropDown(id);
            PopulateSuspensionDropDown(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,Make,Model,Generation,Drivetrain,BodyStyle,BaseHorsepower,EngineSize,Trim")] Car car)
        {
            PopulateBrakesDropDown(car.CarID);
            PopulateEnginePartDropDown(car.CarID);
            PopulateExhaustDropDown(car.CarID);
            PopulateIntakeDropDown(car.CarID);
            PopulateSuspensionDropDown(car.CarID);

            return View(car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void PopulateIntakeDropDown(int? id)
        {
            var intakeList = new List<string>();
            var intakeQuery = from c in db.Cars
                              join p in db.Parts
                              on c.CarID equals p.CarID
                              join i in db.Intakes
                              on p.PartID equals i.PartID
                              where c.CarID == id
                              select i.IntakeName;

            intakeList.AddRange(intakeQuery);
            ViewBag.SelectListIntake = new SelectList(intakeList);
        }

        public void PopulateBrakesDropDown(int? id)
        {
            var brakeList = new List<string>();
            var brakeQuery = from c in db.Cars
                             join p in db.Parts
                             on c.CarID equals p.CarID
                             join i in db.Brakes
                             on p.PartID equals i.PartID
                             where c.CarID == id
                             select i.BrakeName;

            brakeList.AddRange(brakeQuery);
            ViewBag.SelectListBrakes = new SelectList(brakeList);
        }

        public void PopulateEnginePartDropDown(int? id)
        {
            var enginePartList = new List<string>();
            var enginePartQuery = from c in db.Cars
                                  join p in db.Parts
                                  on c.CarID equals p.CarID
                                  join i in db.Brakes
                                  on p.PartID equals i.PartID
                                  where c.CarID == id
                                  select i.BrakeName;

            enginePartList.AddRange(enginePartQuery);
            ViewBag.SelectListEngineParts = new SelectList(enginePartList);
        }

        public void PopulateExhaustDropDown(int? id)
        {
            var exhaustList = new List<string>();
            var exhaustQuery = from c in db.Cars
                               join p in db.Parts
                               on c.CarID equals p.CarID
                               join i in db.Intakes
                               on p.PartID equals i.PartID
                               where c.CarID == id
                               select i.IntakeName;

            exhaustList.AddRange(exhaustQuery);
            ViewBag.SelectListExhaust = new SelectList(exhaustList);
        }

        public void PopulateSuspensionDropDown(int? id)
        {
            var suspensionList = new List<string>();
            var suspensionQuery = from c in db.Cars
                                  join p in db.Parts
                                  on c.CarID equals p.CarID
                                  join i in db.Intakes
                                  on p.PartID equals i.PartID
                                  where c.CarID == id
                                  select i.IntakeName;

            suspensionList.AddRange(suspensionQuery);
            ViewBag.SelectListSuspensions = new SelectList(suspensionList);
        }

        public void PopulateCarDropDown()
        {
            var carMakeQuery = from c in db.Cars
                               orderby c.CarID
                               select c.CarID;
            ViewBag.SelectListCarMakes = new SelectList(carMakeQuery);

            var carModelQuery = from c in db.Cars
                                select c.Model;
            ViewBag.SelectListCarModels = new SelectList(carModelQuery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file) 
        { 
            try 
            { 
                if (file.ContentLength > 0) 
                { 
                    var fileName = Path.GetFileName(file.FileName); 
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName); 
                    file.SaveAs(path); 
                } 
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Create");
            } 
            catch 
            { 
                ViewBag.Message = "Upload failed"; 
                return RedirectToAction("Uploads"); 
            } 
        }

    }
}
