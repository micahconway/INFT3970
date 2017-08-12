namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SemesterCourses");
            DropPrimaryKey("dbo.TrimesterCourses");
            AlterColumn("dbo.SemesterCourses", "SemesterCourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.TrimesterCourses", "TrimesterCourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SemesterCourses", new[] { "SemesterCourseID", "SemesterID", "CourseID" });
            AddPrimaryKey("dbo.TrimesterCourses", new[] { "TrimesterCourseID", "TrimesterID", "CourseID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TrimesterCourses");
            DropPrimaryKey("dbo.SemesterCourses");
            AlterColumn("dbo.TrimesterCourses", "TrimesterCourseID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SemesterCourses", "SemesterCourseID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TrimesterCourses", "TrimesterCourseID");
            AddPrimaryKey("dbo.SemesterCourses", "SemesterCourseID");
        }
    }
}
