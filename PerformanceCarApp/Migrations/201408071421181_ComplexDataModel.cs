namespace PerformanceCarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                        UserBirthday = c.DateTime(nullable: false),
                        Gender = c.String(),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CarID", "dbo.Car");
            DropIndex("dbo.User", new[] { "CarID" });
            DropTable("dbo.User");
        }
    }
}
