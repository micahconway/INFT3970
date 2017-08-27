namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update18 : DbMigration
    {
        public override void Up()
        {
 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "ReplacementCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropColumn("dbo.Replacements", "ReplacementCourse_CourseID");
            DropColumn("dbo.Replacements", "ReplacedCourse_CourseID");
            CreateIndex("dbo.Replacements", "ReplacementCourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourseID");
            AddForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses", "CourseID");
        }
    }
}
