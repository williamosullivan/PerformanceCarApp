using PerformanceCarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PerformanceCarApp.DAL
{
    public class CarInitializer : DropCreateDatabaseIfModelChanges<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            /*var cars = new List<Car>
            {
                new Car{CarID = 1, Make = "VW", Model = "Golf R", BaseHorsepower = 265, BodyStyle = "Hatchback", Drivetrain = "AWD", EngineSize = "4 cylinder Turbo", Generation = "MK6", Trim = "R"},
                new Car{CarID = 2, Make ="GMC", Model="Typhoon", BaseHorsepower= 220, BodyStyle="SUV", Drivetrain="AWD", EngineSize="6 cylinder Turbo", Generation="92/93", Trim = "Typhoon" }
            };
            cars.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();

            var parts = new List<Part>
            {
                new Part{PartID = 1, PartType = "Exhaust"}
            };
            parts.ForEach(s => context.Parts.Add(s));
            context.SaveChanges();

            var exhausts = new List<Exhaust>
            {
                new Exhaust{ExhaustID = 1, PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" }
            };
            exhausts.ForEach(s => context.Exhausts.Add(s));
            context.SaveChanges();

            var brakes = new List<Brakes>
            {
                new Brakes{BrakeID = 1, PartID=2, BrakeWeightSave = 8, BrakeName = "Brembo" }
            };
            brakes.ForEach(s => context.Brakes.Add(s));
            context.SaveChanges();

            var engineParts = new List<EnginePart>
            {
                new EnginePart{EnginePartID = 1, PartID=3, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" }
            };
            engineParts.ForEach(s => context.EngineParts.Add(s));
            context.SaveChanges();

            var intakes = new List<Intake>
            {
                new Intake{IntakeID=1, PartID=4, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" }
            };
            intakes.ForEach(s => context.Intakes.Add(s));
            context.SaveChanges();

            var suspensions = new List<Suspension>
            {
                new Suspension{SuspensionID = 1, PartID = 4, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 }
            };
            suspensions.ForEach(s => context.Suspensions.Add(s));
            context.SaveChanges();*/
        }
    }
}