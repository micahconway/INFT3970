namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" }, "dbo.Replacements");
            DropIndex("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" });
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Replacement_YearDegreeID", c => c.Int());
            AddColumn("dbo.Courses", "Replacement_ReplacementCourseID", c => c.Int());
            AddColumn("dbo.Courses", "Replacement_ReplacedCourseID", c => c.Int());
            CreateIndex("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" });
            AddForeignKey("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" }, "dbo.Replacements", new[] { "ReplacedCourseID", "ReplacementCourseID", "YearDegreeID" });
        }
    }
}
