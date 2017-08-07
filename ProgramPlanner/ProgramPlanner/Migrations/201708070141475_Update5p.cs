namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5p : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrerequisiteCourses",
                c => new
                    {
                        PrerequisiteCourseID = c.Int(nullable: false, identity: true),
                        RequiredCourseID = c.Int(nullable: false),
                        PrerequisiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrerequisiteCourseID)
                .ForeignKey("dbo.Courses", t => t.PrerequisiteID)
                .ForeignKey("dbo.Courses", t => t.RequiredCourseID)
                .Index(t => t.RequiredCourseID)
                .Index(t => t.PrerequisiteID);
            
            AddColumn("dbo.Courses", "PrerequisiteCourses_PrerequisiteCourseID", c => c.Int());
            CreateIndex("dbo.Courses", "PrerequisiteCourses_PrerequisiteCourseID");
            AddForeignKey("dbo.Courses", "PrerequisiteCourses_PrerequisiteCourseID", "dbo.PrerequisiteCourses", "PrerequisiteCourseID", cascadeDelete: true);
            DropColumn("dbo.YearDegrees", "YearDegreeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YearDegrees", "YearDegreeName", c => c.String());
            DropForeignKey("dbo.Courses", "PrerequisiteCourses_PrerequisiteCourseID", "dbo.PrerequisiteCourses");
            DropForeignKey("dbo.PrerequisiteCourses", "RequiredCourseID", "dbo.Courses");
            DropForeignKey("dbo.PrerequisiteCourses", "PrerequisiteID", "dbo.Courses");
            DropIndex("dbo.PrerequisiteCourses", new[] { "PrerequisiteID" });
            DropIndex("dbo.PrerequisiteCourses", new[] { "RequiredCourseID" });
            DropIndex("dbo.Courses", new[] { "PrerequisiteCourses_PrerequisiteCourseID" });
            DropColumn("dbo.Courses", "PrerequisiteCourses_PrerequisiteCourseID");
            DropTable("dbo.PrerequisiteCourses");
        }
    }
}
