namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update15 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID" });
            //DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID1" });
            //DropColumn("dbo.ProgramDirecteds", "ProgramStructureID");
            //DropColumn("dbo.ProgramDirecteds", "ProgramStructureID");
            //RenameColumn(table: "dbo.ProgramDirecteds", name: "ProgramStructure_ProgramStructureID1", newName: "ProgramStructureID");
            //RenameColumn(table: "dbo.ProgramDirecteds", name: "ProgramStructure_ProgramStructureID", newName: "ProgramStructureID");
            DropPrimaryKey("dbo.ProgramDirecteds");
            AlterColumn("dbo.ProgramDirecteds", "ProgramStructureID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID" });
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructureID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructureID" });
            DropPrimaryKey("dbo.ProgramDirecteds");
            AlterColumn("dbo.ProgramDirecteds", "ProgramStructureID", c => c.Int());
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID" });
            RenameColumn(table: "dbo.ProgramDirecteds", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID");
            RenameColumn(table: "dbo.ProgramDirecteds", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID1");
            AddColumn("dbo.ProgramDirecteds", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramDirecteds", "ProgramStructureID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1");
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID");
        }
    }
}
