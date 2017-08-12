namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
