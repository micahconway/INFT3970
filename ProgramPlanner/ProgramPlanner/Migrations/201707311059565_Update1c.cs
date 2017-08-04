namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1c : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
