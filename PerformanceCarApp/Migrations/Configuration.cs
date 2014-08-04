namespace PerformanceCarApp.Migrations
{
    using PerformanceCarApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PerformanceCarApp.DAL.CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PerformanceCarApp.DAL.CarContext context)
        {
            var cars = new List<Car>
            {
                new Car{CarID = 1, Make = "VW", Model = "Golf R", BaseHorsepower = 265, BodyStyle = "Hatchback", Drivetrain = "AWD", EngineSize = "4 cylinder 2.0T", Generation = "MK6", Trim = "R"}
            };
            cars.ForEach(s => context.Cars.AddOrUpdate(s));
            context.SaveChanges();

            var parts = new List<Part>
            {
                new Part{PartID = 1, PartType = "Exhaust"}
            };
            parts.ForEach(s => context.Parts.AddOrUpdate(s));
            context.SaveChanges();

            var exhausts = new List<Exhaust>
            {
                new Exhaust{ExhaustID = 1, PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" }
            };
            exhausts.ForEach(s => context.Exhausts.AddOrUpdate(s));
            context.SaveChanges();

            var brakes = new List<Brakes>
            {
                new Brakes{BrakeID = 1, PartID=2, BrakeWeightSave = 8, BrakeName = "Brembo" }
            };
            brakes.ForEach(s => context.Brakes.AddOrUpdate(s));
            context.SaveChanges();

            var engineParts = new List<EnginePart>
            {
                new EnginePart{EnginePartID = 1, PartID=3, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" }
            };
            engineParts.ForEach(s => context.EngineParts.AddOrUpdate(s));
            context.SaveChanges();

            var intakes = new List<Intake>
            {
                new Intake{IntakeID=1, PartID=4, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" }
            };
            intakes.ForEach(s => context.Intakes.AddOrUpdate(s));
            context.SaveChanges();

            var suspensions = new List<Suspension>
            {
                new Suspension{SuspensionID = 1, PartID = 4, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 }
            };
            suspensions.ForEach(s => context.Suspensions.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}