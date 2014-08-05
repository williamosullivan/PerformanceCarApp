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
                new Car{CarID = 1, Make = "VW", Model = "Golf R", BaseHorsepower = 265, BodyStyle = "Hatchback", Drivetrain = "AWD", EngineSize = "4 cylinder Turbo", Generation = "MK6", Trim = "R"},
                new Car{CarID = 2, Make ="GMC", Model="Typhoon", BaseHorsepower= 220, BodyStyle="SUV", Drivetrain="AWD", EngineSize="6 cylinder Turbo", Generation="92/93", Trim = "Typhoon" }
            };
            cars.ForEach(s => context.Cars.AddOrUpdate(p => p.Model, s));
            context.SaveChanges();

            var parts = new List<Part>
            {
                new Part{PartID = 1, PartType = "Exhaust", CarID = 1 }
            };
            parts.ForEach(s => context.Parts.AddOrUpdate(p => p.PartType, s));
            context.SaveChanges();

            var exhausts = new List<Exhaust>
            {
                new Exhaust{PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" }
            };
            exhausts.ForEach(s => context.Exhausts.AddOrUpdate(p => p.ExhaustName, s));
            context.SaveChanges();

            var brakes = new List<Brakes>
            {
                new Brakes{PartID=2, BrakeWeightSave = 8, BrakeName = "Brembo" }
            };
            brakes.ForEach(s => context.Brakes.AddOrUpdate(p => p.BrakeName, s));
            context.SaveChanges();

            var engineParts = new List<EnginePart>
            {
                new EnginePart{PartID=3, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" }
            };
            engineParts.ForEach(s => context.EngineParts.AddOrUpdate(p => p.EnginePartName, s));
            context.SaveChanges();

            var intakes = new List<Intake>
            {
                new Intake{PartID=4, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" }
            };
            intakes.ForEach(s => context.Intakes.AddOrUpdate(p => p.IntakeName, s));
            context.SaveChanges();

            var suspensions = new List<Suspension>
            {
                new Suspension{PartID = 4, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 }
            };
            suspensions.ForEach(s => context.Suspensions.AddOrUpdate(p => p.SuspensionName, s));
            context.SaveChanges();
        }
    }
}
