namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DegreeCoreSlots", new[] { "YearDegree_YearDegreeID" });
            DropForeignKey("dbo.DegreeCoreSlots", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropColumn("dbo.DegreeCoreSlots", "YearDegree_YearDegreeID");
        }

        public override void Down()
        {
        }
    }
}
