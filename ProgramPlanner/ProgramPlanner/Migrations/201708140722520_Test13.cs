namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees");
            AddForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees", "yearDegreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.Majors", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.Majors", new[] { "YearDegree_YearDegreeID" });
            DropColumn("dbo.Majors", "YearDegree_YearDegreeID");
            AddForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: true);
        }
    }
}
