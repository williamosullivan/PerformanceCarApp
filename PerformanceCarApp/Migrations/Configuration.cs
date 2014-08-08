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
            cars.ForEach(s => context.Cars.AddOrUpdate(p => p.CarID, s));
            context.SaveChanges();

            var parts = new List<Part>
            {
                new Part{PartID = 1, PartType = "Exhaust", CarID = 1 },
                new Part{PartID = 2, PartType = "Exhaust", CarID = 2 },
                new Part{PartID = 3, PartType = "Exhaust", CarID = 3 },
                new Part{PartID = 4, PartType = "Exhaust", CarID = 4 },
                new Part{PartID = 5, PartType = "Exhaust", CarID = 5 },
                new Part{PartID = 6, PartType = "Exhaust", CarID = 6 },
                new Part{PartID = 7, PartType = "Exhaust", CarID = 7 },
                new Part{PartID = 8, PartType = "Exhaust", CarID = 8 },
                new Part{PartID = 9, PartType = "Exhaust", CarID = 9 },
                new Part{PartID = 10, PartType = "Exhaust", CarID = 10},
                new Part{PartID = 11, PartType = "Exhaust", CarID = 11},
                new Part{PartID = 12, PartType = "Brakes", CarID = 1 },
                new Part{PartID = 13, PartType = "Brakes", CarID = 2 },
                new Part{PartID = 14, PartType = "Brakes", CarID = 3 },
                new Part{PartID = 15, PartType = "Brakes", CarID = 4 },
                new Part{PartID = 16, PartType = "Brakes", CarID = 5 },
                new Part{PartID = 17, PartType = "Brakes", CarID = 6 },
                new Part{PartID = 18, PartType = "Brakes", CarID = 7 },
                new Part{PartID = 19, PartType = "Brakes", CarID = 8 },
                new Part{PartID = 20, PartType = "Brakes", CarID = 9 },
                new Part{PartID = 21, PartType = "Brakes", CarID = 10},
                new Part{PartID = 22, PartType = "Brakes", CarID = 11},
                new Part{PartID = 23, PartType = "Air Intake", CarID = 1 },
                new Part{PartID = 24, PartType = "Air Intake", CarID = 2 },
                new Part{PartID = 25, PartType = "Air Intake", CarID = 3 },
                new Part{PartID = 26, PartType = "Air Intake", CarID = 4 },
                new Part{PartID = 27, PartType = "Air Intake", CarID = 5 },
                new Part{PartID = 28, PartType = "Air Intake", CarID = 6 },
                new Part{PartID = 29, PartType = "Air Intake", CarID = 7 },
                new Part{PartID = 30, PartType = "Air Intake", CarID = 8 },
                new Part{PartID = 31, PartType = "Air Intake", CarID = 9 },
                new Part{PartID = 32, PartType = "Air Intake", CarID = 10 },
                new Part{PartID = 33, PartType = "Air Intake", CarID = 11 },
                new Part{PartID = 34, PartType = "Engine Part", CarID = 1 },
                new Part{PartID = 35, PartType = "Engine Part", CarID = 2 },
                new Part{PartID = 36, PartType = "Engine Part", CarID = 3 },
                new Part{PartID = 37, PartType = "Engine Part", CarID = 4 },
                new Part{PartID = 38, PartType = "Engine Part", CarID = 5 },
                new Part{PartID = 39, PartType = "Engine Part", CarID = 6 },
                new Part{PartID = 40, PartType = "Engine Part", CarID = 7 },
                new Part{PartID = 41, PartType = "Engine Part", CarID = 8 },
                new Part{PartID = 42, PartType = "Engine Part", CarID = 9 },
                new Part{PartID = 43, PartType = "Engine Part", CarID = 10},
                new Part{PartID = 44, PartType = "Engine Part", CarID = 11},
                new Part{PartID = 45, PartType = "Suspension", CarID = 1 },
                new Part{PartID = 46, PartType = "Suspension", CarID = 2 },
                new Part{PartID = 47, PartType = "Suspension", CarID = 3 },
                new Part{PartID = 48, PartType = "Suspension", CarID = 4 },
                new Part{PartID = 49, PartType = "Suspension", CarID = 5 },
                new Part{PartID = 50, PartType = "Suspension", CarID = 6 },
                new Part{PartID = 51, PartType = "Suspension", CarID = 7 },
                new Part{PartID = 52, PartType = "Suspension", CarID = 8 },
                new Part{PartID = 53, PartType = "Suspension", CarID = 9 },
                new Part{PartID = 54, PartType = "Suspension", CarID = 10},
                new Part{PartID = 55, PartType = "Suspension", CarID = 11}
            };
            parts.ForEach(s => context.Parts.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var exhausts = new List<Exhaust>
            {
                new Exhaust{PartID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=2, ExhaustHPGain = 20, ExhaustName = "2 in. Flowmaster Full Dual" },
                new Exhaust{PartID=3, ExhaustHPGain = 30, ExhaustName = "3 in. Flowmaster Full Dual" },
                new Exhaust{PartID=4, ExhaustHPGain = 20, ExhaustName = "2 in. Borla Full Dual" },
                new Exhaust{PartID=5, ExhaustHPGain = 30, ExhaustName = "3 in. Borla Full Dual" },
                new Exhaust{PartID=6, ExhaustHPGain = 20, ExhaustName = "2 in. Walker Full Dual" },
                new Exhaust{PartID=7, ExhaustHPGain = 30, ExhaustName = "3 in. Walker Full Dual" },
                new Exhaust{PartID=8, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=9, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=10, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" },
                new Exhaust{PartID=11, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback" }
            };
            exhausts.ForEach(s => context.Exhausts.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var brakes = new List<Brakes>
            {
                new Brakes{PartID=12, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=13, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=14, BrakeWeightSave = 8, BrakeName = "Baer" },
                new Brakes{PartID=15, BrakeWeightSave = 8, BrakeName = "Baer" },
                new Brakes{PartID=16, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=17, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=18, BrakeWeightSave = 8, BrakeName = "Baer" },
                new Brakes{PartID=19, BrakeWeightSave = 8, BrakeName = "Baer" },
                new Brakes{PartID=20, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=21, BrakeWeightSave = 8, BrakeName = "Brembo" },
                new Brakes{PartID=22, BrakeWeightSave = 8, BrakeName = "Baer" }
            };
            brakes.ForEach(s => context.Brakes.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var engineParts = new List<EnginePart>
            {
                new EnginePart{PartID=34, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=35, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=36, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=37, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=38, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=39, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=40, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=41, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=42, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=43, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" },
                new EnginePart{PartID=44, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip" }
            };
            engineParts.ForEach(s => context.EngineParts.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var intakes = new List<Intake>
            {
                new Intake{PartID=23, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=24, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=25, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=26, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=27, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=28, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=29, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=30, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=31, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=32, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
                new Intake{PartID=33, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake" },
            };
            intakes.ForEach(s => context.Intakes.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var suspensions = new List<Suspension>
            {
                new Suspension{PartID = 45, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 46, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 47, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 48, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 49, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 50, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 51, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 52, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 53, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 54, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 },
                new Suspension{PartID = 55, SuspensionDrop = 2, SuspensionName = "KD Coilover", SuspensionWeightSave = 3 }
            };
            suspensions.ForEach(s => context.Suspensions.AddOrUpdate(p => p.PartID, s));
            context.SaveChanges();

            var members = new List<User>
            {
                new User{UserID = 1, UserName = "Bill O'Sullivan", UserEmail = "williamosullivan@gmail.com", UserBirthday = DateTime.Parse("7/23/1981"), Gender = "M", CarID = 1, Horsepower = 300, QuarterMile = 13.2}
            };
            members.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();
        }
    }
}
