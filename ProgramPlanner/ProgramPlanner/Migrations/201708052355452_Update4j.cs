namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4j : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degrees", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Degrees", "Duration");
        }
    }
}
