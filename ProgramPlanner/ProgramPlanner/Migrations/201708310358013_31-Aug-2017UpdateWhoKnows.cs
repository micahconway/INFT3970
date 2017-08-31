namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017UpdateWhoKnows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "detail");
        }
    }
}
