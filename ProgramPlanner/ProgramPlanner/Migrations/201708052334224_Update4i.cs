namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4i : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replacements", "YearDegreeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Replacements", "YearDegreeID");
            AddForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Replacements", new[] { "YearDegreeID" });
            DropColumn("dbo.Replacements", "YearDegreeID");
        }
    }
}
