namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.YearDegrees", "DegreeID", "dbo.Degrees");
            AddForeignKey("dbo.YearDegrees", "DegreeID", "dbo.Degrees", "DegreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearDegrees", "DegreeID", "dbo.Degrees");
            DropForeignKey("dbo.YearDegrees", "Degree_DegreeID", "dbo.Degrees");
            DropIndex("dbo.YearDegrees", new[] { "Degree_DegreeID" });
            DropColumn("dbo.YearDegrees", "Degree_DegreeID");
            AddForeignKey("dbo.YearDegrees", "DegreeID", "dbo.Degrees", "DegreeID", cascadeDelete: true);
        }
    }
}
