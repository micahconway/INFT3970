namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blah : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prerequisites", "CourseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prerequisites", "CourseID");
        }
    }
}
