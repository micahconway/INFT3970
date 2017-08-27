namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update161 : DbMigration
    {
        public override void Up()
        {
    
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramElectives", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgramDirecteds", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.DegreeCores", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.ProgramElectives", new[] { "Course_CourseID" });
            DropIndex("dbo.ProgramDirecteds", new[] { "Course_CourseID" });
            DropIndex("dbo.DegreeCores", new[] { "Course_CourseID" });
            DropColumn("dbo.ProgramElectives", "Course_CourseID");
            DropColumn("dbo.ProgramDirecteds", "Course_CourseID");
            DropColumn("dbo.DegreeCores", "Course_CourseID");
        }
    }
}
