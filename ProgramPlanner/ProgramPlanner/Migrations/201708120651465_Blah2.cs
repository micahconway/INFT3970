namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blah2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prerequisites", "PrerequisiteFor_CourseID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropIndex("dbo.Prerequisites", new[] { "PrerequisiteFor_CourseID" });
            AddForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Courses", "CourseID");
            DropTable("dbo.Prerequisites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        PrerequisiteFor_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrerequisiteID);
            
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Courses");
            DropForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses");
            CreateIndex("dbo.Prerequisites", "PrerequisiteFor_CourseID");
            AddForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID", cascadeDelete: true);
            AddForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Prerequisites", "PrerequisiteFor_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
