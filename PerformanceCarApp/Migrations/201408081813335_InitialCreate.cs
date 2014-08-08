namespace PerformanceCarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brakes",
                c => new
                    {
                        BrakeID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        BrakeWeightSave = c.Int(nullable: false),
                        BrakeName = c.String(),
                    })
                .PrimaryKey(t => t.BrakeID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Generation = c.String(),
                        Drivetrain = c.String(),
                        BodyStyle = c.String(),
                        BaseHorsepower = c.Int(nullable: false),
                        EngineSize = c.String(),
                        Trim = c.String(),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.EnginePart",
                c => new
                    {
                        EnginePartID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        EnginePartHPGain = c.Int(nullable: false),
                        EnginePartName = c.String(),
                    })
                .PrimaryKey(t => t.EnginePartID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Exhaust",
                c => new
                    {
                        ExhaustID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        ExhaustHPGain = c.Int(nullable: false),
                        ExhaustName = c.String(),
                    })
                .PrimaryKey(t => t.ExhaustID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Intake",
                c => new
                    {
                        IntakeID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        IntakeHPGain = c.Int(nullable: false),
                        IntakeName = c.String(),
                    })
                .PrimaryKey(t => t.IntakeID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Suspension",
                c => new
                    {
                        SuspensionID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        SuspensionDrop = c.Int(nullable: false),
                        SuspensionWeightSave = c.Int(nullable: false),
                        SuspensionName = c.String(),
                    })
                .PrimaryKey(t => t.SuspensionID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserBirthday = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Horsepower = c.Int(nullable: false),
                        QuarterMile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CarID", "dbo.Car");
            DropForeignKey("dbo.Suspension", "CarID", "dbo.Car");
            DropForeignKey("dbo.Intake", "CarID", "dbo.Car");
            DropForeignKey("dbo.Exhaust", "CarID", "dbo.Car");
            DropForeignKey("dbo.EnginePart", "CarID", "dbo.Car");
            DropForeignKey("dbo.Brakes", "CarID", "dbo.Car");
            DropIndex("dbo.User", new[] { "CarID" });
            DropIndex("dbo.Suspension", new[] { "CarID" });
            DropIndex("dbo.Intake", new[] { "CarID" });
            DropIndex("dbo.Exhaust", new[] { "CarID" });
            DropIndex("dbo.EnginePart", new[] { "CarID" });
            DropIndex("dbo.Brakes", new[] { "CarID" });
            DropTable("dbo.User");
            DropTable("dbo.Suspension");
            DropTable("dbo.Intake");
            DropTable("dbo.Exhaust");
            DropTable("dbo.EnginePart");
            DropTable("dbo.Car");
            DropTable("dbo.Brakes");
        }
    }
}
