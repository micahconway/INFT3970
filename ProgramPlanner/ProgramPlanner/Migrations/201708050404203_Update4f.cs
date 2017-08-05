namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4f : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropColumn("dbo.Replacements", "ReplacedCourseID");
            DropColumn("dbo.Replacements", "ReplacementCourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourse_CourseID", newName: "ReplacedCourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacementCourse_CourseID", newName: "ReplacementCourseID");
            AlterColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int());
            AlterColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int());
            CreateIndex("dbo.Replacements", "ReplacementCourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Replacements", new[] { "ReplacedCourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacementCourseID" });
            AlterColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Replacements", name: "ReplacementCourseID", newName: "ReplacementCourse_CourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourseID", newName: "ReplacedCourse_CourseID");
            AddColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            AddColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourse_CourseID");
        }
    }
}
