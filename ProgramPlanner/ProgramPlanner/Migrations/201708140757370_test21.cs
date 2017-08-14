namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test21 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructureID" });
            CreateIndex("dbo.ProgramMajors", "ProgramStructureID");
        }
        
        public override void Down()
        {
        }
    }
}
