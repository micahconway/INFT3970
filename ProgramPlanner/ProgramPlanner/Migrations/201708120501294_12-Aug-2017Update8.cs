namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", new[] { "PrerequisiteCourse_PrerequisiteCourseID", "PrerequisiteCourse_PrerequisiteID", "PrerequisiteCourse_RequiredCourseID" }, "dbo.PrerequisiteCourses");
            DropForeignKey("dbo.PrerequisiteCourses", "PrerequisiteID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "Course_CourseID1", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "PrerequisiteCourse_PrerequisiteCourseID", "PrerequisiteCourse_PrerequisiteID", "PrerequisiteCourse_RequiredCourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "PrerequisiteID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "RequiredCourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "Course_CourseID1" });
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PrerequisiteID);
            
            AddColumn("dbo.Courses", "Prerequisite_PrerequisiteID", c => c.Int());
            AddColumn("dbo.Courses", "Prerequisite_PrerequisiteID1", c => c.Int());
            CreateIndex("dbo.Courses", "Prerequisite_PrerequisiteID");
            CreateIndex("dbo.Courses", "Prerequisite_PrerequisiteID1");
            AddForeignKey("dbo.Courses", "Prerequisite_PrerequisiteID", "dbo.Prerequisites", "PrerequisiteID");
            AddForeignKey("dbo.Courses", "Prerequisite_PrerequisiteID1", "dbo.Prerequisites", "PrerequisiteID");
            DropColumn("dbo.Courses", "PrerequisiteCourse_PrerequisiteCourseID");
            DropColumn("dbo.Courses", "PrerequisiteCourse_PrerequisiteID");
            DropColumn("dbo.Courses", "PrerequisiteCourse_RequiredCourseID");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PrerequisiteCourses",
                c => new
                    {
                        PrerequisiteCourseID = c.Int(nullable: false, identity: true),
                        PrerequisiteID = c.Int(nullable: false),
                        RequiredCourseID = c.Int(nullable: false),
                        Course_CourseID = c.Int(),
                        Course_CourseID1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.PrerequisiteCourseID, t.PrerequisiteID, t.RequiredCourseID });
            
            AddColumn("dbo.Courses", "PrerequisiteCourse_RequiredCourseID", c => c.Int());
            AddColumn("dbo.Courses", "PrerequisiteCourse_PrerequisiteID", c => c.Int());
            AddColumn("dbo.Courses", "PrerequisiteCourse_PrerequisiteCourseID", c => c.Int());
            DropForeignKey("dbo.Courses", "Prerequisite_PrerequisiteID1", "dbo.Prerequisites");
            DropForeignKey("dbo.Courses", "Prerequisite_PrerequisiteID", "dbo.Prerequisites");
            DropIndex("dbo.Courses", new[] { "Prerequisite_PrerequisiteID1" });
            DropIndex("dbo.Courses", new[] { "Prerequisite_PrerequisiteID" });
            DropColumn("dbo.Courses", "Prerequisite_PrerequisiteID1");
            DropColumn("dbo.Courses", "Prerequisite_PrerequisiteID");
            DropTable("dbo.Prerequisites");
            CreateIndex("dbo.PrerequisiteCourses", "Course_CourseID1");
            CreateIndex("dbo.PrerequisiteCourses", "Course_CourseID");
            CreateIndex("dbo.PrerequisiteCourses", "RequiredCourseID");
            CreateIndex("dbo.PrerequisiteCourses", "PrerequisiteID");
            CreateIndex("dbo.Courses", new[] { "PrerequisiteCourse_PrerequisiteCourseID", "PrerequisiteCourse_PrerequisiteID", "PrerequisiteCourse_RequiredCourseID" });
            AddForeignKey("dbo.PrerequisiteCourses", "Course_CourseID1", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "PrerequisiteID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Courses", new[] { "PrerequisiteCourse_PrerequisiteCourseID", "PrerequisiteCourse_PrerequisiteID", "PrerequisiteCourse_RequiredCourseID" }, "dbo.PrerequisiteCourses", new[] { "PrerequisiteCourseID", "PrerequisiteID", "RequiredCourseID" });
        }
    }
}
