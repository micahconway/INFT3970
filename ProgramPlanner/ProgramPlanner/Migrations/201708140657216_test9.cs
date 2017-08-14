namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Directeds", "MajorID", "dbo.Majors");
            AddForeignKey("dbo.Directeds", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: false);
            DropIndex("dbo.Directeds", new[] { "MajorID" });
            CreateIndex("dbo.Directeds", "MajorID");
        }
        
        public override void Down()
        {
        }
    }
}
