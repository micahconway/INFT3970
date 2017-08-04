namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3c : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prerequisites", "NewCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "OldCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Prerequisites", new[] { "NewCourse_CourseID" });
            DropIndex("dbo.Prerequisites", new[] { "OldCourse_CourseID" });
            CreateTable(
                "dbo.NeededPrereqs",
                c => new
                    {
                        NeededPrereqID = c.Int(nullable: false, identity: true),
                        Course = c.Int(nullable: false),
                        PrerequisiteCourseID = c.Int(nullable: false),
                        RequiredCourse_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.NeededPrereqID)
                .ForeignKey("dbo.Courses", t => t.RequiredCourse_CourseID)
                .Index(t => t.RequiredCourse_CourseID);
            
            CreateTable(
                "dbo.PrerequisiteCourses",
                c => new
                    {
                        PrerequisiteCourseID = c.Int(nullable: false),
                        Course = c.Int(nullable: false),
                        NeededPrereqID = c.Int(nullable: false),
                        RequiredCourse_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.PrerequisiteCourseID)
                .ForeignKey("dbo.NeededPrereqs", t => t.PrerequisiteCourseID)
                .ForeignKey("dbo.Courses", t => t.RequiredCourse_CourseID)
                .Index(t => t.PrerequisiteCourseID)
                .Index(t => t.RequiredCourse_CourseID);
            
            DropTable("dbo.Prerequisites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteID = c.Int(nullable: false, identity: true),
                        OldCourseID = c.Int(nullable: false),
                        NewCourseID = c.Int(nullable: false),
                        NewCourse_CourseID = c.Int(),
                        OldCourse_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.PrerequisiteID);
            
            DropForeignKey("dbo.NeededPrereqs", "RequiredCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "PrerequisiteCourseID", "dbo.NeededPrereqs");
            DropIndex("dbo.PrerequisiteCourses", new[] { "RequiredCourse_CourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "PrerequisiteCourseID" });
            DropIndex("dbo.NeededPrereqs", new[] { "RequiredCourse_CourseID" });
            DropTable("dbo.PrerequisiteCourses");
            DropTable("dbo.NeededPrereqs");
            CreateIndex("dbo.Prerequisites", "OldCourse_CourseID");
            CreateIndex("dbo.Prerequisites", "NewCourse_CourseID");
            AddForeignKey("dbo.Prerequisites", "OldCourse_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Prerequisites", "NewCourse_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
