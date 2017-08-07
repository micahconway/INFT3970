namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4k : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrerequisiteCourses", "PrerequisiteCourseID", "dbo.NeededPrereqs");
            DropForeignKey("dbo.NeededPrereqs", "RequiredCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.NeededPrereqs", new[] { "RequiredCourse_CourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "PrerequisiteCourseID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "RequiredCourse_CourseID" });
            RenameColumn(table: "dbo.PrerequisiteCourses", name: "RequiredCourse_CourseID", newName: "RequiredCourseID");
            DropPrimaryKey("dbo.PrerequisiteCourses");
            AlterColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PrerequisiteCourses", "RequiredCourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PrerequisiteCourses", "PrerequisiteCourseID");
            CreateIndex("dbo.PrerequisiteCourses", "RequiredCourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            DropColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseName");
            DropColumn("dbo.PrerequisiteCourses", "Course");
            DropColumn("dbo.PrerequisiteCourses", "NeededPrereqID");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NeededPrereqs",
                c => new
                    {
                        NeededPrereqID = c.Int(nullable: false, identity: true),
                        NeededPrereqName = c.String(),
                        Course = c.Int(nullable: false),
                        PrerequisiteCourseID = c.Int(nullable: false),
                        RequiredCourse_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.NeededPrereqID);
            
            AddColumn("dbo.PrerequisiteCourses", "NeededPrereqID", c => c.Int(nullable: false));
            AddColumn("dbo.PrerequisiteCourses", "Course", c => c.Int(nullable: false));
            AddColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseName", c => c.String());
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses");
            DropIndex("dbo.PrerequisiteCourses", new[] { "RequiredCourseID" });
            DropPrimaryKey("dbo.PrerequisiteCourses");
            AlterColumn("dbo.PrerequisiteCourses", "RequiredCourseID", c => c.Int());
            AlterColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PrerequisiteCourses", "PrerequisiteCourseID");
            RenameColumn(table: "dbo.PrerequisiteCourses", name: "RequiredCourseID", newName: "RequiredCourse_CourseID");
            CreateIndex("dbo.PrerequisiteCourses", "RequiredCourse_CourseID");
            CreateIndex("dbo.PrerequisiteCourses", "PrerequisiteCourseID");
            CreateIndex("dbo.NeededPrereqs", "RequiredCourse_CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "RequiredCourse_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.NeededPrereqs", "RequiredCourse_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "PrerequisiteCourseID", "dbo.NeededPrereqs", "NeededPrereqID");
        }
    }
}
