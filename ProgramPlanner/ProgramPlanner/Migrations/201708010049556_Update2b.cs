namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2b : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Majors", new[] { "YearDegree_yearDegreeID" });
            AddColumn("dbo.YearDegrees", "YearDegreeName", c => c.String());
            CreateIndex("dbo.Majors", "YearDegree_YearDegreeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Majors", new[] { "YearDegree_YearDegreeID" });
            DropColumn("dbo.YearDegrees", "YearDegreeName");
            CreateIndex("dbo.Majors", "YearDegree_yearDegreeID");
        }
    }
}
