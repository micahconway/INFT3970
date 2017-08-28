namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27Aug20161 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramElectives", new[] { "CourseID" });
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "CourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            CreateIndex("dbo.ProgramElectives", "CourseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgramElectives", new[] { "CourseID" });
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "CourseID", c => c.Int());
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            RenameColumn(table: "dbo.ProgramElectives", name: "CourseID", newName: "Course_CourseID");
            AddColumn("dbo.ProgramElectives", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramElectives", "Course_CourseID");
            CreateIndex("dbo.ProgramElectives", "CourseID");
        }
    }
}
