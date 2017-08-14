namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MajorCores");
            AddPrimaryKey("dbo.MajorCores", new[] { "CourseID", "MajorID" });        }
        
        public override void Down()
        {
            AddColumn("dbo.MajorCores", "MajorCoreID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.MajorCores");
            AddPrimaryKey("dbo.MajorCores", new[] { "MajorCoreID", "CourseID", "MajorID" });
        }
    }
}
