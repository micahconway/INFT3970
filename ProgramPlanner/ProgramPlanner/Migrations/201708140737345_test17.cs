namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test17 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID1" });
            DropColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID");
            DropColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1");
        }

        public override void Down()
        {
        }
    }
}
