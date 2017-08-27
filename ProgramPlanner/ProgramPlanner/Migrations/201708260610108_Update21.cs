namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserID");
        }
    }
}
