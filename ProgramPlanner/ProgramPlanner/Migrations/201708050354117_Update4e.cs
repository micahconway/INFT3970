namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replacements",
                c => new
                    {
                        ReplacementID = c.Int(nullable: false, identity: true),
                        ReplacementCourseID = c.Int(nullable: false),
                        ReplacedCourseID = c.Int(nullable: false),
                        ReplacedCourse_CourseID = c.Int(),
                        ReplacementCourse_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.ReplacementID)
                .ForeignKey("dbo.Courses", t => t.ReplacedCourse_CourseID)
                .ForeignKey("dbo.Courses", t => t.ReplacementCourse_CourseID)
                .Index(t => t.ReplacedCourse_CourseID)
                .Index(t => t.ReplacementCourse_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replacements", "ReplacementCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Replacements", "ReplacedCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Replacements", new[] { "ReplacementCourse_CourseID" });
            DropIndex("dbo.Replacements", new[] { "ReplacedCourse_CourseID" });
            DropTable("dbo.Replacements");
        }
    }
}
