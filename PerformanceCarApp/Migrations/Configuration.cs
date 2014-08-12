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

            var exhausts = new List<Exhaust>
            {
                new Exhaust{ExhaustID=1, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback", CarID = 1 },
                new Exhaust{ExhaustID=2, ExhaustHPGain = 20, ExhaustName = "2 in. Flowmaster Full Dual", CarID = 2},
                new Exhaust{ExhaustID=3, ExhaustHPGain = 30, ExhaustName = "3 in. Flowmaster Full Dual", CarID = 3},
                new Exhaust{ExhaustID=4, ExhaustHPGain = 20, ExhaustName = "2 in. Borla Full Dual", CarID = 4},
                new Exhaust{ExhaustID=5, ExhaustHPGain = 30, ExhaustName = "3 in. Borla Full Dual", CarID = 5},
                new Exhaust{ExhaustID=6, ExhaustHPGain = 20, ExhaustName = "2 in. Walker Full Dual", CarID = 6},
                new Exhaust{ExhaustID=7, ExhaustHPGain = 30, ExhaustName = "3 in. Walker Full Dual", CarID = 7},
                new Exhaust{ExhaustID=8, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback", CarID = 8},
                new Exhaust{ExhaustID=9, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback", CarID = 9},
                new Exhaust{ExhaustID=10, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback", CarID = 10},
                new Exhaust{ExhaustID=11, ExhaustHPGain = 12, ExhaustName = "42 Draft Designs Turboback", CarID = 11},
            };
            exhausts.ForEach(s => context.Exhausts.AddOrUpdate(p => p.ExhaustID, s));
            context.SaveChanges();

            var brakes = new List<Brakes>
            {
                new Brakes{BrakeID=12, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 1},
                new Brakes{BrakeID=13, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 2},
                new Brakes{BrakeID=14, BrakeWeightSave = 8, BrakeName = "Baer", CarID = 3},
                new Brakes{BrakeID=15, BrakeWeightSave = 8, BrakeName = "Baer", CarID = 4},
                new Brakes{BrakeID=16, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 5},
                new Brakes{BrakeID=17, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 6},
                new Brakes{BrakeID=18, BrakeWeightSave = 8, BrakeName = "Baer", CarID = 7},
                new Brakes{BrakeID=19, BrakeWeightSave = 8, BrakeName = "Baer", CarID = 8},
                new Brakes{BrakeID=20, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 9},
                new Brakes{BrakeID=21, BrakeWeightSave = 8, BrakeName = "Brembo", CarID = 10},
                new Brakes{BrakeID=22, BrakeWeightSave = 8, BrakeName = "Baer", CarID = 11},
            };
            brakes.ForEach(s => context.Brakes.AddOrUpdate(p => p.BrakeID, s));
            context.SaveChanges();

            var engineParts = new List<EnginePart>
            {
                new EnginePart{EnginePartID=34, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 1 },
                new EnginePart{EnginePartID=35, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 2 },
                new EnginePart{EnginePartID=36, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 3 },
                new EnginePart{EnginePartID=37, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 4 },
                new EnginePart{EnginePartID=38, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 5 },
                new EnginePart{EnginePartID=39, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 6 },
                new EnginePart{EnginePartID=40, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 7 },
                new EnginePart{EnginePartID=41, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 8 },
                new EnginePart{EnginePartID=42, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 9 },
                new EnginePart{EnginePartID=43, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 10 },
                new EnginePart{EnginePartID=44, EnginePartHPGain = 65, EnginePartName = "APR ECU Chip", CarID = 11 },
            };
            engineParts.ForEach(s => context.EngineParts.AddOrUpdate(p => p.EnginePartID, s));
            context.SaveChanges();

            var intakes = new List<Intake>
            {
                new Intake{IntakeID=23, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 1 },
                new Intake{IntakeID=24, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 2 },
                new Intake{IntakeID=25, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 3 },
                new Intake{IntakeID=26, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 4 },
                new Intake{IntakeID=27, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 5 },
                new Intake{IntakeID=28, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 6 },
                new Intake{IntakeID=29, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 7 },
                new Intake{IntakeID=30, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 8 },
                new Intake{IntakeID=31, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 9 },
                new Intake{IntakeID=32, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 10 },
                new Intake{IntakeID=33, IntakeHPGain = 14, IntakeName = "CTS Turbo Cold Air Intake", CarID = 11 }
            };
            intakes.ForEach(s => context.Intakes.AddOrUpdate(p => p.IntakeID, s));
            context.SaveChanges();

            var suspensions = new List<Suspension>
            {
                new Suspension{SuspensionID = 45, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 1 },
                new Suspension{SuspensionID = 46, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 2 },
                new Suspension{SuspensionID = 47, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 3 },
                new Suspension{SuspensionID = 48, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 4 },
                new Suspension{SuspensionID = 49, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 5 },
                new Suspension{SuspensionID = 50, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 6 },
                new Suspension{SuspensionID = 51, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 7 },
                new Suspension{SuspensionID = 52, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 8 },
                new Suspension{SuspensionID = 53, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 9 },
                new Suspension{SuspensionID = 54, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 10 },
                new Suspension{SuspensionID = 55, SuspensionDrop = 2, SuspensionName = "KD Coilover", CarID = 11 }
            };
            suspensions.ForEach(s => context.Suspensions.AddOrUpdate(p => p.SuspensionID, s));
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
