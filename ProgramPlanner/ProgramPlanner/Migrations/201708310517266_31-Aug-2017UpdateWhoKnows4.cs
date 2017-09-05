namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017UpdateWhoKnows4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Information", c => c.String());
            DropColumn("dbo.Courses", "details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "details", c => c.String());
            DropColumn("dbo.Courses", "Information");
        }
    }
}
