namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prerequisites", "HelloID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prerequisites", "HelloID");
        }
    }
}
