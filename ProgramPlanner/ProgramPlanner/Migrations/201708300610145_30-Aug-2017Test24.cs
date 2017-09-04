namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test24 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramDirecteds", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.ProgramDirecteds", new[] { "Course_CourseID" });
           // DropColumn("dbo.ProgramDirecteds", "Course_CourseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramDirecteds", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.ProgramDirecteds", "Course_CourseID");
            AddForeignKey("dbo.ProgramDirecteds", "Course_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
