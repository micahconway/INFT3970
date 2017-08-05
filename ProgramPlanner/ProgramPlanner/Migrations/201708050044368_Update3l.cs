namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SemesterCourses",
                c => new
                    {
                        SemesterCourseID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterCourseID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: true)
                .Index(t => t.SemesterID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        SemesterValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.TrimesterCourses",
                c => new
                    {
                        TrimesterCourseID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        TrimesterID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrimesterCourseID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Trimesters", t => t.TrimesterID, cascadeDelete: true)
                .Index(t => t.TrimesterID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Trimesters",
                c => new
                    {
                        TrimesterID = c.Int(nullable: false, identity: true),
                        TrimesterValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrimesterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrimesterCourses", "TrimesterID", "dbo.Trimesters");
            DropForeignKey("dbo.TrimesterCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.SemesterCourses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.SemesterCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.TrimesterCourses", new[] { "CourseID" });
            DropIndex("dbo.TrimesterCourses", new[] { "TrimesterID" });
            DropIndex("dbo.SemesterCourses", new[] { "CourseID" });
            DropIndex("dbo.SemesterCourses", new[] { "SemesterID" });
            DropTable("dbo.Trimesters");
            DropTable("dbo.TrimesterCourses");
            DropTable("dbo.Semesters");
            DropTable("dbo.SemesterCourses");
        }
    }
}
