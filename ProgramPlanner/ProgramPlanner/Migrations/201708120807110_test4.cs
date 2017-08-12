namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Replacements");
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacedCourseID", "ReplacementCourseID", "YearDegreeID" });
            DropColumn("dbo.Replacements", "ReplacementID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replacements", "ReplacementID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Replacements");
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementID", "ReplacedCourseID", "ReplacementCourseID" });
        }
    }
}
