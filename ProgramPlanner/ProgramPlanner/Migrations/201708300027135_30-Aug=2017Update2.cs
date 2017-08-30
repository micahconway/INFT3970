namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Update2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Replacement", new[] { "ReplacementCourseID" });
            DropForeignKey("dbo.Replacement", "ReplacementCourseID", "dbo.Courses");
            DropPrimaryKey("dbo.Replacements");
            AddColumn("dbo.Replacements", "ReplacementID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementID", "YearDegreeID" });
            //DropColumn("dbo.Replacements", "ReplacementCourseID");

           // DropColumn("dbo.Courses", "ReplacementID");
            //AddColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: true));
            //CreateIndex("dbo.Courses", "ReplacementID");
            //AddForeignKey("dbo.Courses", "ReplacementID", "dbo.Replacement", "ReplacementCourseID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replacements", "ReplacementCourseID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Replacements");
            DropColumn("dbo.Replacements", "ReplacementID");
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementCourseID", "YearDegreeID" });
        }
    }
}
