namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test48 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SemesterCourses");
            DropPrimaryKey("dbo.TrimesterCourses");
            AddPrimaryKey("dbo.SemesterCourses", new[] { "SemesterID", "CourseID" });
            AddPrimaryKey("dbo.TrimesterCourses", new[] { "TrimesterID", "CourseID" });
            DropColumn("dbo.SemesterCourses", "SemesterCourseID");
            DropColumn("dbo.TrimesterCourses", "TrimesterCourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrimesterCourses", "TrimesterCourseID", c => c.Int(nullable: false));
            AddColumn("dbo.SemesterCourses", "SemesterCourseID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.TrimesterCourses");
            DropPrimaryKey("dbo.SemesterCourses");
            AddPrimaryKey("dbo.TrimesterCourses", new[] { "TrimesterCourseID", "TrimesterID", "CourseID" });
            AddPrimaryKey("dbo.SemesterCourses", new[] { "SemesterCourseID", "SemesterID", "CourseID" });
        }
    }
}
