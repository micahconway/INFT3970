namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Replacements", new[] { "ReplacedCourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropPrimaryKey("dbo.Replacements");
            AddColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: false));
            //AlterColumn("dbo.Replacements", "ReplacementCourse_CourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementCourseID", "YearDegreeID" });
            //CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
            //DropColumn("dbo.Replacements", "ReplacedCourseID");
            //DropColumn("dbo.Replacements", "ReplacedCourse_CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replacements", "ReplacedCourse_CourseID", c => c.Int());
            AddColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropPrimaryKey("dbo.Replacements");
            AlterColumn("dbo.Replacements", "ReplacementCourse_CourseID", c => c.Int());
            DropColumn("dbo.Courses", "ReplacementID");
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacedCourseID", "ReplacementCourseID", "YearDegreeID" });
            CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourse_CourseID");
            AddForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
