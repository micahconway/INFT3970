namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test100 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramElectives");
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            AlterColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int(nullable: false));
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramElectives", "CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID", "OptionalCoreID" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProgramElectives", new[] { "CourseID" });
            DropIndex("dbo.Majors", new[] { "YearDegreeID" });
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID" });
            DropIndex("dbo.OptionalCoreCourses", new[] { "DegreeCoreSlotID" });
            DropPrimaryKey("dbo.ProgramOptionalCoreCourses");
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int());
            AlterColumn("dbo.ProgramElectives", "CourseID", c => c.Int());
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int());
            AlterColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int());
            AddPrimaryKey("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID", "OptionalCoreID" });
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            RenameColumn(table: "dbo.ProgramOptionalCoreCourses", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID");
            RenameColumn(table: "dbo.OptionalCoreCourses", name: "DegreeCoreSlotID", newName: "DegreeCoreSlot_DegreeCoreSlotID");
            RenameColumn(table: "dbo.Majors", name: "YearDegreeID", newName: "YearDegree_YearDegreeID");
            RenameColumn(table: "dbo.ProgramElectives", name: "CourseID", newName: "Course_CourseID");
            AddColumn("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramElectives", "CourseID", c => c.Int(nullable: false));
            AddColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramOptionalCoreCourses", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramOptionalCoreCourses", "ProgramStructureID");
            CreateIndex("dbo.ProgramElectives", "Course_CourseID");
            CreateIndex("dbo.ProgramElectives", "CourseID");
            CreateIndex("dbo.Majors", "YearDegree_YearDegreeID");
            CreateIndex("dbo.Majors", "YearDegreeID");
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID");
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlotID");
        }
    }
}
