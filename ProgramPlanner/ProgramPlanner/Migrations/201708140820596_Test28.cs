namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test28 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID", "dbo.OptionalCoreCourses");
            DropColumn("dbo.ProgramOptionalCoreCourses", "OptionalCoreCourse_OptionalCoreCourseID");
            AddForeignKey("dbo.ProgramOptionalCoreCourses", "OptionalCoreID", "dbo.OptionalCoreCourses", "OptionalCoreCourseID");
        }

        public override void Down()
        {
        }
    }
}
