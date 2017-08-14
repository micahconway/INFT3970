namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramDirecteds", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.YearDegrees", "DegreeCores_DegreeCoreID", "dbo.DegreeCores");
            DropForeignKey("dbo.YearDegrees", "Majors_MajorID", "dbo.Majors");
            DropForeignKey("dbo.DegreeCores", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.Majors", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.Directeds", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramStructures", "UserID", "dbo.Users");
            DropIndex("dbo.YearDegrees", new[] { "DegreeCores_DegreeCoreID" });
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            DropIndex("dbo.Majors", new[] { "YearDegree_YearDegreeID" });
            DropIndex("dbo.Directeds", new[] { "CourseID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "CourseID" });
            DropIndex("dbo.ProgramStructures", new[] { "UserID" });
           /* RenameColumn(table: "dbo.DegreeCores", name: "DegreeCores_DegreeCoreID", newName: "YearDegreeID");
            RenameColumn(table: "dbo.Majors", name: "Majors_MajorID", newName: "YearDegreeID");
            RenameColumn(table: "dbo.DegreeCores", name: "YearDegree_YearDegreeID", newName: "YearDegreeID");
            RenameColumn(table: "dbo.Majors", name: "YearDegree_YearDegreeID", newName: "YearDegreeID");
            RenameColumn(table: "dbo.Directeds", name: "CourseID", newName: "Course_CourseID");
            RenameColumn(table: "dbo.ProgramStructures", name: "UserID", newName: "Email");*/
            DropPrimaryKey("dbo.DegreeCores");
            DropPrimaryKey("dbo.MajorCores");
            DropPrimaryKey("dbo.ProgramDirecteds");
            DropPrimaryKey("dbo.ProgramMajors");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.ProgramDirecteds", "DirectedID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID", c => c.Int());
            AddColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1", c => c.Int(nullable: false));
            AlterColumn("dbo.Universities", "UniName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Degrees", "DegreeName", c => c.String());
            AlterColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            //AlterColumn("dbo.Directeds", "Course_CourseID", c => c.Int());
            //AlterColumn("dbo.ProgramStructures", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DegreeCores", new[] { "CourseID", "YearDegreeID" });
            AddPrimaryKey("dbo.MajorCores", new[] { "CourseID", "MajorID" });
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID" });
            AddPrimaryKey("dbo.ProgramMajors", new[] { "ProgramStructureID", "MajorID" });
            AddPrimaryKey("dbo.Users", "Email");
            CreateIndex("dbo.DegreeCores", "YearDegreeID");
            CreateIndex("dbo.Majors", "YearDegreeID");
            //CreateIndex("dbo.Directeds", "Course_CourseID");
            CreateIndex("dbo.ProgramDirecteds", "DirectedID");
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1");
            //CreateIndex("dbo.ProgramStructures", "Email");
            AddForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.Directeds", "DirectedID");
            AddForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: false);
            //AddForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: false);
            //AddForeignKey("dbo.Directeds", "Course_CourseID", "dbo.Courses", "CourseID");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            //AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email", cascadeDelete: false);
            DropColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
            DropColumn("dbo.YearDegrees", "Majors_MajorID");
            DropColumn("dbo.DegreeCores", "DegreeCoreID");
            DropColumn("dbo.MajorCores", "MajorCoreID");
            DropColumn("dbo.ProgramDirecteds", "ProgramDirectedID");
            DropColumn("dbo.ProgramDirecteds", "CourseID");
            DropColumn("dbo.ProgramMajors", "ProgramMajorID");
            DropColumn("dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ProgramMajors", "ProgramMajorID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ProgramDirecteds", "CourseID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramDirecteds", "ProgramDirectedID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.MajorCores", "MajorCoreID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DegreeCores", "DegreeCoreID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int(nullable: false));
            AddColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProgramStructures", "Email", "dbo.Users");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1", "dbo.ProgramStructures");
            DropForeignKey("dbo.Directeds", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.Directeds");
            DropIndex("dbo.ProgramStructures", new[] { "Email" });
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID1" });
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructure_ProgramStructureID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "DirectedID" });
            DropIndex("dbo.Directeds", new[] { "Course_CourseID" });
            DropIndex("dbo.Majors", new[] { "YearDegreeID" });
            DropIndex("dbo.DegreeCores", new[] { "YearDegreeID" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.ProgramMajors");
            DropPrimaryKey("dbo.ProgramDirecteds");
            DropPrimaryKey("dbo.MajorCores");
            DropPrimaryKey("dbo.DegreeCores");
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramStructures", "Email", c => c.Int(nullable: false));
            AlterColumn("dbo.Directeds", "Course_CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int());
            AlterColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int());
            AlterColumn("dbo.Degrees", "DegreeName", c => c.String(nullable: false));
            AlterColumn("dbo.Universities", "UniName", c => c.String(nullable: false));
            DropColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID1");
            DropColumn("dbo.ProgramDirecteds", "ProgramStructure_ProgramStructureID");
            DropColumn("dbo.ProgramDirecteds", "DirectedID");
            AddPrimaryKey("dbo.Users", "UserID");
            AddPrimaryKey("dbo.ProgramMajors", "ProgramMajorID");
            AddPrimaryKey("dbo.ProgramDirecteds", "ProgramDirectedID");
            AddPrimaryKey("dbo.MajorCores", "MajorCoreID");
            AddPrimaryKey("dbo.DegreeCores", "DegreeCoreID");
            RenameColumn(table: "dbo.ProgramStructures", name: "Email", newName: "UserID");
            RenameColumn(table: "dbo.Directeds", name: "Course_CourseID", newName: "CourseID");
            RenameColumn(table: "dbo.Majors", name: "YearDegreeID", newName: "YearDegree_YearDegreeID");
            RenameColumn(table: "dbo.DegreeCores", name: "YearDegreeID", newName: "YearDegree_YearDegreeID");
            RenameColumn(table: "dbo.Majors", name: "YearDegreeID", newName: "Majors_MajorID");
            RenameColumn(table: "dbo.DegreeCores", name: "YearDegreeID", newName: "DegreeCores_DegreeCoreID");
            AddColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramStructures", "UserID");
            CreateIndex("dbo.ProgramDirecteds", "CourseID");
            CreateIndex("dbo.ProgramDirecteds", "ProgramStructureID");
            CreateIndex("dbo.Directeds", "CourseID");
            CreateIndex("dbo.Majors", "YearDegree_YearDegreeID");
            CreateIndex("dbo.DegreeCores", "YearDegree_YearDegreeID");
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
            CreateIndex("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
            AddForeignKey("dbo.ProgramStructures", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.ProgramDirecteds", "ProgramStructureID", "dbo.ProgramStructures", "ProgramStructureID", cascadeDelete: true);
            AddForeignKey("dbo.Directeds", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Majors", "YearDegree_YearDegreeID", "dbo.YearDegrees", "YearDegreeID");
            AddForeignKey("dbo.DegreeCores", "YearDegree_YearDegreeID", "dbo.YearDegrees", "YearDegreeID");
            AddForeignKey("dbo.YearDegrees", "Majors_MajorID", "dbo.Majors", "MajorID");
            AddForeignKey("dbo.YearDegrees", "DegreeCores_DegreeCoreID", "dbo.DegreeCores", "DegreeCoreID");
            AddForeignKey("dbo.ProgramDirecteds", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
