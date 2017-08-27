namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update20 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramStructures", new[] { "Email" });
            DropIndex("dbo.ProgramStructures", new[] { "User_Email" });
            DropPrimaryKey("dbo.ProgramMajors");
            AlterColumn("dbo.ProgramStructures", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProgramMajors", new[] { "ProgramStructureID", "MajorID" });
            CreateIndex("dbo.ProgramStructures", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "ReplacementCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramStructures", "Email", "dbo.Users");
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramStructures", new[] { "Email" });
            DropPrimaryKey("dbo.ProgramMajors");
            AlterColumn("dbo.ProgramMajors", "ProgramStructureID", c => c.Int());
            AlterColumn("dbo.ProgramStructures", "Email", c => c.String(maxLength: 128));
            DropColumn("dbo.Replacements", "ReplacementCourse_CourseID");
            DropColumn("dbo.Replacements", "ReplacedCourse_CourseID");
            AddPrimaryKey("dbo.ProgramMajors", new[] { "ProgramStructureID", "MajorID" });
            RenameColumn(table: "dbo.ProgramStructures", name: "Email", newName: "User_Email");
            RenameColumn(table: "dbo.ProgramMajors", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID");
            RenameColumn(table: "dbo.ProgramMajors", name: "ProgramStructureID", newName: "ProgramStructure_ProgramStructureID1");
            AddColumn("dbo.ProgramMajors", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramMajors", "ProgramStructureID", c => c.Int(nullable: false));
            AddColumn("dbo.ProgramStructures", "Email", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Replacements", "ReplacementCourseID");
            CreateIndex("dbo.Replacements", "ReplacedCourseID");
            CreateIndex("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID1");
            CreateIndex("dbo.ProgramMajors", "ProgramStructure_ProgramStructureID");
            CreateIndex("dbo.ProgramStructures", "User_Email");
            CreateIndex("dbo.ProgramStructures", "Email");
            AddForeignKey("dbo.Replacements", "ReplacementCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Replacements", "ReplacedCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users", "Email");
        }
    }
}
