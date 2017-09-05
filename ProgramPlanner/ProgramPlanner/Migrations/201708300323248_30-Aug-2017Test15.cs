namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test15 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "Course_CourseID" });
            DropIndex("dbo.Directeds", new[] { "Course_CourseID" });
        }

        public override void Down()
        {
        }
    }
}
