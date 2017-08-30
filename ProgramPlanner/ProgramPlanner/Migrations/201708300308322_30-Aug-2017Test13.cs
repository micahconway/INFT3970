namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test13 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MajorCores", new[] { "MajorID" });
            DropIndex("dbo.MajorCores", new[] { "CourseID" });
            DropForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors");
            CreateIndex("dbo.MajorCores", "MajorID");
            CreateIndex("dbo.MajorCores", "CourseID");
            AddForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors", "MajorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses");
            AddForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: true);
            AddForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
