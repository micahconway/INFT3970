namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12Aug2017Update10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prerequisites", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.Prerequisites", new[] { "Course_CourseID" });
            CreateTable(
                "dbo.OptionalPrerequisites",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        PrerequisiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.PrerequisiteID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Prerequisites", t => t.PrerequisiteID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PrerequisiteID);
            
            DropColumn("dbo.Prerequisites", "Course_CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prerequisites", "Course_CourseID", c => c.Int());
            DropForeignKey("dbo.OptionalPrerequisites", "PrerequisiteID", "dbo.Prerequisites");
            DropForeignKey("dbo.OptionalPrerequisites", "CourseID", "dbo.Courses");
            DropIndex("dbo.OptionalPrerequisites", new[] { "PrerequisiteID" });
            DropIndex("dbo.OptionalPrerequisites", new[] { "CourseID" });
            DropTable("dbo.OptionalPrerequisites");
            CreateIndex("dbo.Prerequisites", "Course_CourseID");
            AddForeignKey("dbo.Prerequisites", "Course_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
