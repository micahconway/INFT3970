namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramDirecteds", new[] { "Course_CourseID" });
            DropForeignKey("dbo.ProgramDirecteds", "Course_CourseID", "dbo.Courses");
            //DropColumn("dbo.ProgramDirecteds", "Course_CourseID");

        }

        public override void Down()
        {
        }
    }
}
