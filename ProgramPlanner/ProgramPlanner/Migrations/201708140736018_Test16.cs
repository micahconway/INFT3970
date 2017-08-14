namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.SemesterCourses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.TrimesterCourses", "TrimesterID", "dbo.Trimesters");
            AddForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.SemesterCourses", "SemesterID", "dbo.Semesters", "SemesterID");
            AddForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.TrimesterCourses", "TrimesterID", "dbo.Trimesters", "TrimesterID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrimesterCourses", "TrimesterID", "dbo.Trimesters");
            DropForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.SemesterCourses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses");
            AddForeignKey("dbo.TrimesterCourses", "TrimesterID", "dbo.Trimesters", "TrimesterID", cascadeDelete: true);
            AddForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.SemesterCourses", "SemesterID", "dbo.Semesters", "SemesterID", cascadeDelete: true);
            AddForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
