namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors");
            AddForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: false);
            AddForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: false);
        }

        public override void Down()
        {
        }
    }
}
