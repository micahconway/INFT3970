namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test11 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramDirecteds", new[] { "Course_CourseID" });
            //DropColumn("dbo.ProgramDirecteds", "Course_CourseID");

        }

        public override void Down()
        {
        }
    }
}
