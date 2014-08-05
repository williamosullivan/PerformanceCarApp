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
                        PartID = c.Int(nullable: false, identity: true),
                        BrakeWeightSave = c.Int(nullable: false),
                        BrakeName = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        PartType = c.String(),
                        Brakes_PartID = c.Int(),
                        EnginePart_PartID = c.Int(),
                        Exhaust_PartID = c.Int(),
                        Intake_PartID = c.Int(),
                        Suspension_PartID = c.Int(),
                    })
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.Brakes", t => t.Brakes_PartID)
                .ForeignKey("dbo.EnginePart", t => t.EnginePart_PartID)
                .ForeignKey("dbo.Exhaust", t => t.Exhaust_PartID)
                .ForeignKey("dbo.Intake", t => t.Intake_PartID)
                .ForeignKey("dbo.Suspension", t => t.Suspension_PartID)
                .Index(t => t.Brakes_PartID)
                .Index(t => t.EnginePart_PartID)
                .Index(t => t.Exhaust_PartID)
                .Index(t => t.Intake_PartID)
                .Index(t => t.Suspension_PartID);
            
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
                        PartID = c.Int(nullable: false, identity: true),
                        EnginePartHPGain = c.Int(nullable: false),
                        EnginePartName = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.Exhaust",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        ExhaustHPGain = c.Int(nullable: false),
                        ExhaustName = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.Intake",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        IntakeHPGain = c.Int(nullable: false),
                        IntakeName = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.Suspension",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        SuspensionDrop = c.Int(nullable: false),
                        SuspensionWeightSave = c.Int(nullable: false),
                        SuspensionName = c.String(),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.CarPart",
                c => new
                    {
                        Car_CarID = c.Int(nullable: false),
                        Part_PartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_CarID, t.Part_PartID })
                .ForeignKey("dbo.Car", t => t.Car_CarID, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.Part_PartID, cascadeDelete: true)
                .Index(t => t.Car_CarID)
                .Index(t => t.Part_PartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Part", "Suspension_PartID", "dbo.Suspension");
            DropForeignKey("dbo.Part", "Intake_PartID", "dbo.Intake");
            DropForeignKey("dbo.Part", "Exhaust_PartID", "dbo.Exhaust");
            DropForeignKey("dbo.Part", "EnginePart_PartID", "dbo.EnginePart");
            DropForeignKey("dbo.CarPart", "Part_PartID", "dbo.Part");
            DropForeignKey("dbo.CarPart", "Car_CarID", "dbo.Car");
            DropForeignKey("dbo.Part", "Brakes_PartID", "dbo.Brakes");
            DropIndex("dbo.CarPart", new[] { "Part_PartID" });
            DropIndex("dbo.CarPart", new[] { "Car_CarID" });
            DropIndex("dbo.Part", new[] { "Suspension_PartID" });
            DropIndex("dbo.Part", new[] { "Intake_PartID" });
            DropIndex("dbo.Part", new[] { "Exhaust_PartID" });
            DropIndex("dbo.Part", new[] { "EnginePart_PartID" });
            DropIndex("dbo.Part", new[] { "Brakes_PartID" });
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
