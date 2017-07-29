namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        DegreeID = c.Int(nullable: false, identity: true),
                        DegreeName = c.String(),
                    })
                .PrimaryKey(t => t.DegreeID);
            
            CreateTable(
                "dbo.YearDegrees",
                c => new
                    {
                        yearDegreeID = c.Int(nullable: false, identity: true),
                        Year = c.DateTime(nullable: false),
                        DegreeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.yearDegreeID)
                .ForeignKey("dbo.Degrees", t => t.DegreeID, cascadeDelete: true)
                .Index(t => t.DegreeID);
            
            AddColumn("dbo.Courses", "MajorID", c => c.Int());
            AddColumn("dbo.Courses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "MajorID");
            AddForeignKey("dbo.Courses", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearDegrees", "DegreeID", "dbo.Degrees");
            DropForeignKey("dbo.Courses", "MajorID", "dbo.Majors");
            DropIndex("dbo.YearDegrees", new[] { "DegreeID" });
            DropIndex("dbo.Courses", new[] { "MajorID" });
            DropColumn("dbo.Courses", "Discriminator");
            DropColumn("dbo.Courses", "MajorID");
            DropTable("dbo.YearDegrees");
            DropTable("dbo.Degrees");
        }
    }
}
