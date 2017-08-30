namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test25 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            CreateIndex("dbo.DegreeCores", "YearDegreeID");
            AlterColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "ReplacementID", c => c.Int());
        }
    }
}
