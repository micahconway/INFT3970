namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test22 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructureID" });
            CreateIndex("dbo.ProgramElectives", "ProgramStructureID");
        }
        
        public override void Down()
        {
        }
    }
}
