namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropColumn("dbo.Replacements", "ReplacedCourseID");
            DropColumn("dbo.Replacements", "ReplacementCourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourse_CourseID", newName: "ReplacedCourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacementCourse_CourseID", newName: "ReplacementCourseID");
            DropPrimaryKey("dbo.Replacements");
            AlterColumn("dbo.Replacements", "ReplacementID", c => c.Int(nullable: false));
            AlterColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementID", "ReplacedCourseID", "ReplacementCourseID" });
            CreateIndex("dbo.Replacements", "ReplacedCourseID");
            CreateIndex("dbo.Replacements", "ReplacementCourseID");
            AddForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Replacements", new[] { "ReplacementCourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourseID" });
            DropPrimaryKey("dbo.Replacements");
            AlterColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int());
            AlterColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int());
            AlterColumn("dbo.Replacements", "ReplacementID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Replacements", "ReplacementID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacementCourseID", newName: "ReplacementCourse_CourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourseID", newName: "ReplacedCourse_CourseID");
            AddColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            AddColumn("dbo.Replacements", "ReplacedCourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourse_CourseID");
            AddForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: false);
        }
    }
}
