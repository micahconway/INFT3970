namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017UpdateWhoKnows1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "details", c => c.String());
            DropColumn("dbo.Courses", "detail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "detail", c => c.String());
            DropColumn("dbo.Courses", "details");
        }
    }
}
