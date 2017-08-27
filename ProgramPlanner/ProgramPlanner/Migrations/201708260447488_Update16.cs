namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update16 : DbMigration
    {
        public override void Up()
        {
            
            //RenameColumn(table: "dbo.ProgramElectives", name: "ProgramStructure_ProgramStructureID1", newName: "ProgramStructureID");
            //RenameColumn(table: "dbo.ProgramElectives", name: "ProgramStructure_ProgramStructureID", newName: "ProgramStructureID");
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "ProgramStructureID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
           
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructureID" });
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "ProgramStructureID", c => c.Int());
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            RenameColumn(table: "dbo.ProgramElectives", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID");
            RenameColumn(table: "dbo.ProgramElectives", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID1");
            AddColumn("dbo.ProgramElectives", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramElectives", "ProgramStructureID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID1");
            CreateIndex("dbo.ProgramElectives", "ProgramStructure_ProgramStructureID");
        }
    }
}
