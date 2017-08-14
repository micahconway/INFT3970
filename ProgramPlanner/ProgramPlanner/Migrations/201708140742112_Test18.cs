namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramElectives", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses");
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructureID" });
            AddColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1", c => c.Int());
            CreateIndex("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1");
            AddForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures", "ProgramStructureID");
            AddForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures");
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructure_ProgramStructureID1" });
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructure_ProgramStructureID" });
            DropColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1");
            DropColumn("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramElectives", "ProgramStructureID");
            AddForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.ProgramElectives", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID", cascadeDelete: true);
        }
    }
}
