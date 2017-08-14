namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures");
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructure_ProgramStructureID" });
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructure_ProgramStructureID1" });
            DropColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID");
            DropColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1");
        }
        
        public override void Down()
        {
        }
    }
}
