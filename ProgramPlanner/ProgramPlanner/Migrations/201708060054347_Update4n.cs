namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4n : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses");
            AddColumn("dbo.PrerequisiteCourses", "PrerequisiteID", c => c.Int(nullable: false));
            AddColumn("dbo.PrerequisiteCourses", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.PrerequisiteCourses", "PrerequisiteID");
            CreateIndex("dbo.PrerequisiteCourses", "Course_CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "PrerequisiteID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "PrerequisiteID", "dbo.Courses");
            DropIndex("dbo.PrerequisiteCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "PrerequisiteID" });
            DropColumn("dbo.PrerequisiteCourses", "Course_CourseID");
            DropColumn("dbo.PrerequisiteCourses", "PrerequisiteID");
            AddForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
