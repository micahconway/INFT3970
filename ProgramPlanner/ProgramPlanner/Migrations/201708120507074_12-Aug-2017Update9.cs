namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MandatoryPrerquisites",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PrerequisiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PrerequisiteID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Prerequisites", t => t.PrerequisiteID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PrerequisiteID);
            
            AddColumn("dbo.Prerequisites", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.Prerequisites", "Course_CourseID");
            AddForeignKey("dbo.Prerequisites", "Course_CourseID", "dbo.Courses", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prerequisites", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.MandatoryPrerquisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.MandatoryPrerquisites", "CourseID", "dbo.Courses");
            DropIndex("dbo.MandatoryPrerquisites", new[] { "PrerequisiteID" });
            DropIndex("dbo.MandatoryPrerquisites", new[] { "CourseID" });
            DropIndex("dbo.Prerequisites", new[] { "Course_CourseID" });
            DropColumn("dbo.Prerequisites", "Course_CourseID");
            DropTable("dbo.MandatoryPrerquisites");
        }
    }
}
