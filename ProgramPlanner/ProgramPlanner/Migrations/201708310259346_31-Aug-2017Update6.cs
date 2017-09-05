namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "ReplacementID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: false));
        }
    }
}
