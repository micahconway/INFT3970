namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5m : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.PrerequisiteCourses", new[] { "Course_CourseID" });
            DropTable("dbo.PrerequisiteCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PrerequisiteCourses",
                c => new
                    {
                        PrerequisiteCourseID = c.Int(nullable: false, identity: true),
                        RequiredCourseID = c.Int(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.PrerequisiteCourseID);
            
            CreateIndex("dbo.PrerequisiteCourses", "Course_CourseID");
            AddForeignKey("dbo.PrerequisiteCourses", "Course_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
