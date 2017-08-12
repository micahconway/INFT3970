namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropIndex("dbo.MandatoryPrerquisites", new[] { "CourseID" });
            DropIndex("dbo.MandatoryPrerquisites", new[] { "PrerequisiteID" });
            DropIndex("dbo.OptionalPrerequisites", new[] { "CourseID" });
            DropIndex("dbo.OptionalPrerequisites", new[] { "PrerequisiteID" });
            DropTable("dbo.MandatoryPrerquisites");
            DropTable("dbo.OptionalPrerequisites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OptionalPrerequisites",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PrerequisiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PrerequisiteID });
            
            CreateTable(
                "dbo.MandatoryPrerquisites",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PrerequisiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PrerequisiteID });
            
            CreateIndex("dbo.OptionalPrerequisites", "PrerequisiteID");
            CreateIndex("dbo.OptionalPrerequisites", "CourseID");
            CreateIndex("dbo.MandatoryPrerquisites", "PrerequisiteID");
            CreateIndex("dbo.MandatoryPrerquisites", "CourseID");
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
