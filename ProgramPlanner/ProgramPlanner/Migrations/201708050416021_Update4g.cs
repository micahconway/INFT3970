namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4g : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
