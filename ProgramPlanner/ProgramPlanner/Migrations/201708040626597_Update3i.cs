namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3i : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramStructures",
                c => new
                    {
                        ProgramStructureID = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramStructureID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ProgramDirecteds",
                c => new
                    {
                        ProgramDirectedID = c.Int(nullable: false, identity: true),
                        ProgramStructureID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramDirectedID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramStructures", t => t.ProgramStructureID, cascadeDelete: true)
                .Index(t => t.ProgramStructureID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.ProgramElectives",
                c => new
                    {
                        ProgramElectiveID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        ProgramStructureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramElectiveID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramStructures", t => t.ProgramStructureID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.ProgramStructureID);
            
            CreateTable(
                "dbo.ProgramMajors",
                c => new
                    {
                        ProgramMajorID = c.Int(nullable: false, identity: true),
                        ProgramStructureID = c.Int(nullable: false),
                        MajorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramMajorID)
                .ForeignKey("dbo.Majors", t => t.MajorID, cascadeDelete: true)
                .ForeignKey("dbo.ProgramStructures", t => t.ProgramStructureID, cascadeDelete: true)
                .Index(t => t.ProgramStructureID)
                .Index(t => t.MajorID);
            
            CreateTable(
                "dbo.ProgramOptionalCoreCourses",
                c => new
                    {
                        ProgramOptionalCoreCourseID = c.Int(nullable: false, identity: true),
                        ProgramStructureID = c.Int(nullable: false),
                        OptionalCoreID = c.Int(nullable: false),
                        OptionalCoreCourse_OptionalCoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramOptionalCoreCourseID)
                .ForeignKey("dbo.ProgramStructures", t => t.ProgramStructureID, cascadeDelete: true)
                .Index(t => t.ProgramStructureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramStructures", "UserID", "dbo.Users");
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramMajors", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramMajors", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.ProgramElectives", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramElectives", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramDirecteds", "ProgramStructureID", "dbo.ProgramStructures");
            DropForeignKey("dbo.ProgramDirecteds", "CourseID", "dbo.Courses");
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramMajors", new[] { "MajorID" });
            DropIndex("dbo.ProgramMajors", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramElectives", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramElectives", new[] { "CourseID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "CourseID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "ProgramStructureID" });
            DropIndex("dbo.ProgramStructures", new[] { "UserID" });
            DropTable("dbo.ProgramOptionalCoreCourses");
            DropTable("dbo.ProgramMajors");
            DropTable("dbo.ProgramElectives");
            DropTable("dbo.ProgramDirecteds");
            DropTable("dbo.ProgramStructures");
        }
    }
}
