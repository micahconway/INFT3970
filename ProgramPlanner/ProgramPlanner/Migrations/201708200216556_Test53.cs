namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramDirecteds", "Completed", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramElectives", "Completed", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramOptionalCoreCourses", "Completed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramOptionalCoreCourses", "Completed");
            DropColumn("dbo.ProgramElectives", "Completed");
            DropColumn("dbo.ProgramDirecteds", "Completed");
        }
    }
}
