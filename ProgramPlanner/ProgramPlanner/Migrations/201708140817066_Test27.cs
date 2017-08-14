namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test27 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", "dbo.ProgramStructures");
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "OptionalCoreCourse_OptionalCoreCourseID" });
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            AlterColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID", "OptionalCoreID" });
            CreateIndex("dbo.ProgramOptionalCoreCourses", "OptionalCoreID");
            AddForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID");
            DropColumn("dbo.ProgramOptionalCoreCourses", "ProgramOptionalCoreCourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramOptionalCoreCourses", "ProgramOptionalCoreCourseID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructure_ProgramStructureID" });
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "OptionalCoreID" });
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            AlterColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int());
            DropColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructure_ProgramStructureID");
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", "ProgramOptionalCoreCourseID");
            RenameColumn(table: "dbo.ProgramOptionalCoreCourses", name: "OptionalCoreID", newName: "OptionalCoreCourse_OptionalCoreCourseID");
            AddColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
            AddForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID", cascadeDelete: true);
        }
    }
}
