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
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MakeSortParm = sortOrder == "Make" ? "make_desc" : "Make";
            var cars = from c in db.Cars
                       select c;

            cars = cars.Where(c => c.Model.ToUpper().Contains(searchString.ToUpper())
            || c.Make.ToUpper().Contains(searchString.ToUpper()) || c.Generation.ToUpper().
            Contains(searchString.ToUpper()) || c.Drivetrain.ToUpper().Contains(searchString.ToUpper()) ||
            c.EngineSize.ToUpper().Contains(searchString.ToUpper()));

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
            PopulateBaseHorsepower(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = new Car();
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
            var auto = db.Cars.Find(id);
            var stock = new Intake();
            stock.IntakeName = "Stock";
            stock.IntakeHPGain = 0;
            var intakeList = new List<string>();
            var intakeQuery = from c in db.Intakes
                              where c.CarID == auto.CarID
                              select c.IntakeName;
            intakeList.Add(stock.IntakeName);
            intakeList.AddRange(intakeQuery);
            ViewBag.SelectListIntake = new SelectList(intakeList);
        }

        public void PopulateBrakesDropDown(int? id)
        {
            var auto = db.Cars.Find(id);
            var stock = new Brakes();
            stock.BrakeName = "Stock";
            stock.BrakeWeightSave = 0;
            var brakeList = new List<string>();
            var brakeQuery = from c in db.Brakes
                             where c.CarID == auto.CarID
                             select c.BrakeName;
            brakeList.Add(stock.BrakeName);
            brakeList.AddRange(brakeQuery);
            ViewBag.SelectListBrakes = new SelectList(brakeList);
        }

        public void PopulateEnginePartDropDown(int? id)
        {
            var auto = db.Cars.Find(id);
            var stock = new EnginePart();
            stock.EnginePartName = "Stock";
            stock.EnginePartHPGain = 0;
            var enginePartList = new List<string>();
            var enginePartQuery = from c in db.EngineParts
                                  where c.CarID == auto.CarID
                                  select c.EnginePartName;
            enginePartList.Add(stock.EnginePartName);
            enginePartList.AddRange(enginePartQuery);
            ViewBag.SelectListEngineParts = new SelectList(enginePartList);
        }

        public void PopulateExhaustDropDown(int? id)
        {
            var auto = db.Cars.Find(id);
            var stock = new Exhaust();
            stock.ExhaustName = "Stock";
            stock.ExhaustHPGain = 0;
            var exhaustList = new List<string>();
            var exhaustQuery = from c in db.Exhausts
                               where c.CarID == auto.CarID
                               select c.ExhaustName;
            exhaustList.Add(stock.ExhaustName);
            exhaustList.AddRange(exhaustQuery);
            ViewBag.SelectListExhaust = new SelectList(exhaustList);
        }

        public void PopulateSuspensionDropDown(int? id)
        {
            var auto = db.Cars.Find(id);
            var suspensionList = new List<string>();
            var stock = new Suspension();
            stock.SuspensionName = "Stock";
            stock.SuspensionWeightSave = 0;
            stock.SuspensionDrop = 0;
            var suspensionQuery = from c in db.Suspensions
                                  where c.CarID == auto.CarID
                                  select c.SuspensionName;
            suspensionList.Add(stock.SuspensionName);
            suspensionList.AddRange(suspensionQuery);
            ViewBag.SelectListSuspensions = new SelectList(suspensionList);
        }

        public void PopulateCarDropDown(Car selectedCar)
        {
            var carMakeQuery = from c in db.Cars
                               orderby c.Make
                               select c;
            ViewBag.SelectListCarMakes = new SelectList(carMakeQuery, "CarID", "Make");

            var carModelQuery = from c in db.Cars
                                select c.Model;
            ViewBag.SelectListCarModels = new SelectList(carModelQuery);
        }

        public void PopulateBaseHorsepower(int? id)
        {
            Car car = db.Cars.Find(id);
            ViewBag.BHP = car.BaseHorsepower;
        }

        public void PopulateProjectedHorsepower(string name)
        {
            Intake intake = db.Intakes.Find(name);
            if (intake != null)
                ViewBag.HP += intake.IntakeHPGain;
            else
                ViewBag.HP = ViewBag.HP;
        }

        public void PopulateEnginePartHP(string name)
        {
            EnginePart ep = db.EngineParts.Find(name);
            if (ep != null)
                ViewBag.HP += ep.EnginePartHPGain;
            else
                ViewBag.HP = ViewBag.HP;
        }

        public void PopulateExhaustHP(string name)
        {
            Exhaust ex = db.Exhausts.Find(name);
              if (ex != null)
                ViewBag.HP += ex.ExhaustHPGain;
              else
                 ViewBag.HP = ViewBag.HP;
                
        }
    
        public void PopulateSuspensionDrop(string name)
        {
            Suspension sus = db.Suspensions.Find(name);
            if (sus != null)
                ViewBag.Drop = sus.SuspensionDrop;
            else
                ViewBag.SuspDrop = 0;
        }

        public void PopulateWeightSave(string name)
        {
            Brakes brake = db.Brakes.Find(name);
            if (brake != null)
                ViewBag.Weight = brake.BrakeWeightSave;
            else
            {
                Suspension suspension = db.Suspensions.Find(name);
                if (suspension != null)
                    ViewBag.Weight = suspension.SuspensionWeightSave;
                else
                    ViewBag.Weight = 0;
            }
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
