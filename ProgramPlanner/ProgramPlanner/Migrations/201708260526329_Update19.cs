namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacementCourse_CourseID", "dbo.Courses");
            //DropColumn("dbo.Replacements", "ReplacedCourseID");
            //DropColumn("dbo.Replacements", "ReplacementCourseID");
            //RenameColumn(table: "dbo.Replacements", name: "ReplacedCourse_CourseID", newName: "ReplacedCourseID");
            //RenameColumn(table: "dbo.Replacements", name: "ReplacementCourse_CourseID", newName: "ReplacementCourseID");
            //RenameIndex(table: "dbo.Replacements", name: "IX_ReplacedCourse_CourseID", newName: "IX_ReplacedCourseID");
            //RenameIndex(table: "dbo.Replacements", name: "IX_ReplacementCourse_CourseID", newName: "IX_ReplacementCourseID");
            AddForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses");
            RenameIndex(table: "dbo.Replacements", name: "IX_ReplacementCourseID", newName: "IX_ReplacementCourse_CourseID");
            RenameIndex(table: "dbo.Replacements", name: "IX_ReplacedCourseID", newName: "IX_ReplacedCourse_CourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacementCourseID", newName: "ReplacementCourse_CourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourseID", newName: "ReplacedCourse_CourseID");
            AddColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            AddColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Replacements", "ReplacementCourse_CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
