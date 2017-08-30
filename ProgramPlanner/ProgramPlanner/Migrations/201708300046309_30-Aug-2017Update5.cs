namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Update5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Replacements");
            AddPrimaryKey("dbo.Replacements", "ReplacementID");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.Replacements");
            AddPrimaryKey("dbo.Replacements", new[] { "ReplacementID", "YearDegreeID" });
            RenameIndex(table: "dbo.Replacements", name: "IX_ReplacementID", newName: "IX_ReplacementCourse_CourseID");
            RenameColumn(table: "dbo.Replacements", name: "ReplacementID", newName: "ReplacementCourse_CourseID");
            AddColumn("dbo.Replacements", "ReplacementID", c => c.Int(nullable: false));
        }
    }
}
