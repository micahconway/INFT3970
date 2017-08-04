namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3b : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.PrerequisiteID)
                .ForeignKey("dbo.Courses", t => t.NewCourse_CourseID)
                .ForeignKey("dbo.Courses", t => t.OldCourse_CourseID)
                .Index(t => t.NewCourse_CourseID)
                .Index(t => t.OldCourse_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prerequisites", "OldCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "NewCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Prerequisites", new[] { "OldCourse_CourseID" });
            DropIndex("dbo.Prerequisites", new[] { "NewCourse_CourseID" });
            DropTable("dbo.Prerequisites");
        }
    }
}
