namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update162 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" }, "dbo.Replacements");
            DropIndex("dbo.Courses", new[] { "Replacement_ReplacedCourseID", "Replacement_ReplacementCourseID", "Replacement_YearDegreeID" });
            DropColumn("dbo.Courses", "Replacement_YearDegreeID");
            DropColumn("dbo.Courses", "Replacement_ReplacementCourseID");
            DropColumn("dbo.Courses", "Replacement_ReplacedCourseID");
        }
    }
}
