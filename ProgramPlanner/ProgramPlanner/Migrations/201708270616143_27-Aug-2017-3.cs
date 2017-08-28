namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27Aug20173 : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID", "dbo.OptionalCoreCourses");
            DropIndex("dbo.ProgramOptionalCoreCourses", new[] { "OptionalCoreCourse_OptionalCoreCourseID" });
            DropColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
        }
    }
}
