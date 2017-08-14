namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramMajors", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramMajors", "MajorID", "dbo.Majors");
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructureID" });
            CreateIndex("dbo.ProgramMajors", "ProgramStructureID");
            AddForeignKey("dbo.ProgramMajors", "MajorID", "dbo.Majors", "MajorID");
            AddForeignKey("dbo.ProgramMajors", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramMajors", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures");
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructure_ProgramStructureID1" });
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructure_ProgramStructureID" });
            DropColumn("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID1");
            DropColumn("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramMajors", "ProgramStructureID");
            AddForeignKey("dbo.ProgramMajors", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: true);
            AddForeignKey("dbo.ProgramMajors", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID", cascadeDelete: true);
        }
    }
}
