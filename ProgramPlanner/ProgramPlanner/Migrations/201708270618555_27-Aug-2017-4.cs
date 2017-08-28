namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27Aug20174 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            AlterColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID", "OptionalCoreID" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "OptionalCoreID" });
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID" });
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            AlterColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int());
            AlterColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int());
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID", "OptionalCoreID" });
            RenameColumn(table: "dbo.ProgramOptionalCoreCourses", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID");
            RenameColumn(table: "dbo.ProgramOptionalCoreCourses", name: "OptionalCoreID", newName: "OptionalCoreCourse_OptionalCoreCourseID");
            AddColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
            CreateIndex("dbo.ProgramOptionalCoreCourses", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramOptionalCoreCourses", "OptionalCoreID");
            CreateIndex("dbo.ProgramOptionalCoreCourses", "ProgramStructureID");
        }
    }
}
