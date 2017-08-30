namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test82 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            AddForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            AlterColumn("dbo.Replacements", "ReplacementCourse_CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Replacements", "ReplacedCourse_CourseID", c => c.Int());
            RenameColumn(table: "dbo.Replacements", name: "ReplacedCourse_CourseID", newName: "ReplacementCourse_CourseID");
            AddColumn("dbo.Replacements", "ReplacedCourse_CourseID", c => c.Int());
            CreateIndex("dbo.Replacements", "ReplacementCourse_CourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourse_CourseID");
            AddForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID");
        }
    }
}
