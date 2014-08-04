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
                        PartID = c.Int(nullable: false),
                        BrakeWeightSave = c.Int(nullable: false),
                        BrakeName = c.String(),
                    })
                .PrimaryKey(t => t.BrakeID);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        CarID = c.Int(nullable: false),
                        PartID = c.Int(nullable: false),
                        PartType = c.String(),
                        Brakes_BrakeID = c.Int(),
                        EnginePart_EnginePartID = c.Int(),
                        Exhaust_ExhaustID = c.Int(),
                        Intake_IntakeID = c.Int(),
                        Suspension_SuspensionID = c.Int(),
                    })
                .PrimaryKey(t => new { t.CarID, t.PartID })
                .ForeignKey("dbo.Brakes", t => t.Brakes_BrakeID)
                .ForeignKey("dbo.EnginePart", t => t.EnginePart_EnginePartID)
                .ForeignKey("dbo.Exhaust", t => t.Exhaust_ExhaustID)
                .ForeignKey("dbo.Intake", t => t.Intake_IntakeID)
                .ForeignKey("dbo.Suspension", t => t.Suspension_SuspensionID)
                .Index(t => t.Brakes_BrakeID)
                .Index(t => t.EnginePart_EnginePartID)
                .Index(t => t.Exhaust_ExhaustID)
                .Index(t => t.Intake_IntakeID)
                .Index(t => t.Suspension_SuspensionID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
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
                        PartID = c.Int(nullable: false),
                        EnginePartHPGain = c.Int(nullable: false),
                        EnginePartName = c.String(),
                    })
                .PrimaryKey(t => t.EnginePartID);
            
            CreateTable(
                "dbo.Exhaust",
                c => new
                    {
                        ExhaustID = c.Int(nullable: false, identity: true),
                        PartID = c.Int(nullable: false),
                        ExhaustHPGain = c.Int(nullable: false),
                        ExhaustName = c.String(),
                    })
                .PrimaryKey(t => t.ExhaustID);
            
            CreateTable(
                "dbo.Intake",
                c => new
                    {
                        IntakeID = c.Int(nullable: false, identity: true),
                        PartID = c.Int(nullable: false),
                        IntakeHPGain = c.Int(nullable: false),
                        IntakeName = c.String(),
                    })
                .PrimaryKey(t => t.IntakeID);
            
            CreateTable(
                "dbo.Suspension",
                c => new
                    {
                        SuspensionID = c.Int(nullable: false, identity: true),
                        PartID = c.Int(nullable: false),
                        SuspensionDrop = c.Int(nullable: false),
                        SuspensionWeightSave = c.Int(nullable: false),
                        SuspensionName = c.String(),
                    })
                .PrimaryKey(t => t.SuspensionID);
            
            CreateTable(
                "dbo.CarPart",
                c => new
                    {
                        Car_CarID = c.Int(nullable: false),
                        Part_CarID = c.Int(nullable: false),
                        Part_PartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_CarID, t.Part_CarID, t.Part_PartID })
                .ForeignKey("dbo.Car", t => t.Car_CarID, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => new { t.Part_CarID, t.Part_PartID }, cascadeDelete: true)
                .Index(t => t.Car_CarID)
                .Index(t => new { t.Part_CarID, t.Part_PartID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Part", "Suspension_SuspensionID", "dbo.Suspension");
            DropForeignKey("dbo.Part", "Intake_IntakeID", "dbo.Intake");
            DropForeignKey("dbo.Part", "Exhaust_ExhaustID", "dbo.Exhaust");
            DropForeignKey("dbo.Part", "EnginePart_EnginePartID", "dbo.EnginePart");
            DropForeignKey("dbo.CarPart", new[] { "Part_CarID", "Part_PartID" }, "dbo.Part");
            DropForeignKey("dbo.CarPart", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Part", "Brakes_BrakeID", "dbo.Brakes");
            DropIndex("dbo.CarPart", new[] { "Part_CarID", "Part_PartID" });
            DropIndex("dbo.CarPart", new[] { "Car_CarID" });
            DropIndex("dbo.Part", new[] { "Suspension_SuspensionID" });
            DropIndex("dbo.Part", new[] { "Intake_IntakeID" });
            DropIndex("dbo.Part", new[] { "Exhaust_ExhaustID" });
            DropIndex("dbo.Part", new[] { "EnginePart_EnginePartID" });
            DropIndex("dbo.Part", new[] { "Brakes_BrakeID" });
            DropTable("dbo.CarPart");
            DropTable("dbo.Suspension");
            DropTable("dbo.Intake");
            DropTable("dbo.Exhaust");
            DropTable("dbo.EnginePart");
            DropTable("dbo.Car");
            DropTable("dbo.Part");
            DropTable("dbo.Brakes");
        }
    }
}
