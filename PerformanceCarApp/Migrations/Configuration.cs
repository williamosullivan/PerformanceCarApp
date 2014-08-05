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
                new Car{CarID = 2, Make ="GMC", Model="Typhoon", BaseHorsepower= 220, BodyStyle="SUV", Drivetrain="AWD", EngineSize="6 cylinder Turbo", Generation="92/93", Trim = "Typhoon" },
                new Car{CarID = 3, Make ="Chevrolet", Model="Camero", BaseHorsepower= 300, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2010", Trim = "SS" },
                new Car{CarID = 4, Make ="Ford", Model="Fusion", BaseHorsepower= 250, BodyStyle="2 dr. Coupe", Drivetrain="FWD", EngineSize="V6", Generation="2010", Trim = "SEL" },
                new Car{CarID = 5, Make ="Ford", Model="Focus", BaseHorsepower= 190, BodyStyle="3dr Hatchback", Drivetrain="FWD", EngineSize="I4", Generation="2009", Trim = "SE" },
                new Car{CarID = 6, Make ="Ford", Model="Mustang", BaseHorsepower= 300, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2012", Trim = "GT" },
                new Car{CarID = 7, Make ="Chevrolet", Model="Impala", BaseHorsepower= 250, BodyStyle="2 dr. Coupe", Drivetrain="FWD", EngineSize="V6", Generation="2008", Trim = "SS" },
                new Car{CarID = 8, Make ="Chevrolet", Model="Corvette", BaseHorsepower= 350, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2012", Trim = "Stingray" },
                new Car{CarID = 9, Make ="Chevrolet", Model="Corvette", BaseHorsepower= 400, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2006", Trim = "Z06" },
                new Car{CarID = 10, Make ="Dodge", Model="Charger", BaseHorsepower= 300, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2010", Trim = "RT" },
                new Car{CarID = 11, Make ="Dodge", Model="Challenger", BaseHorsepower= 300, BodyStyle="2 dr. Coupe", Drivetrain="RWD", EngineSize="V8", Generation="2012", Trim = "RT" }

            };
            cars.ForEach(s => context.Cars.AddOrUpdate(p => p.Model, s));
            context.SaveChanges();

            var parts = new List<Part>
            {
            new Part{PartID = 1, PartType = "Exhaust", CarID = 1 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 2 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 3 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 4 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 5 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 6 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 7 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 8 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 9 },
            new Part{PartID = 1, PartType = "Exhaust", CarID = 10},
            new Part{PartID = 1, PartType = "Exhaust", CarID = 11},
            new Part{PartID = 2, PartType = "Header", CarID = 1 },
            new Part{PartID = 2, PartType = "Header", CarID = 2 },
            new Part{PartID = 2, PartType = "Header", CarID = 3 },
            new Part{PartID = 2, PartType = "Header", CarID = 4 },
            new Part{PartID = 2, PartType = "Header", CarID = 5 },
            new Part{PartID = 2, PartType = "Header", CarID = 6 },
            new Part{PartID = 2, PartType = "Header", CarID = 7 },
            new Part{PartID = 2, PartType = "Header", CarID = 8 },
            new Part{PartID = 2, PartType = "Header", CarID = 9 },
            new Part{PartID = 2, PartType = "Header", CarID = 10},
            new Part{PartID = 2, PartType = "Header", CarID = 11},
            new Part{PartID = 3, PartType = "Air Intake", CarID = 1 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 2 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 3 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 4 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 5 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 6 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 7 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 8 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 9 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 10 },
            new Part{PartID = 3, PartType = "Air Intake", CarID = 11 }
            };
            parts.ForEach(s => context.Parts.AddOrUpdate(p => p.PartType, s));
            context.SaveChanges();

            var exhausts = new List<Exhaust>
            {
                new Exhaust{PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=2, ExhaustHPGain = 20, ExhaustName = "2 in. Flowmaster Full Dual" },
                new Exhaust{PartID=3, ExhaustHPGain = 30, ExhaustName = "3 in. Flowmaster Full Dual" },
                new Exhaust{PartID=4, ExhaustHPGain = 20, ExhaustName = "2 in. Borla Full Dual" },
                new Exhaust{PartID=5, ExhaustHPGain = 30, ExhaustName = "3 in. Borla Full Dual" },
                new Exhaust{PartID=6, ExhaustHPGain = 20, ExhaustName = "2 in. Walker Full Dual" },
                new Exhaust{PartID=7, ExhaustHPGain = 30, ExhaustName = "3 in. Walker Full Dual" }
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
