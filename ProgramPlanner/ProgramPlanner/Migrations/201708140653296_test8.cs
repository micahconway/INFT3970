namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Directeds", "MajorID", "dbo.Majors");
            AddForeignKey("dbo.Directeds", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: false);
            DropIndex("dbo.Directeds", new[] { "MajorID" });
            CreateIndex("dbo.Directeds", "MajorID");
            AddForeignKey("dbo.Directeds", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: false);
        }

        public override void Down()
        {
        }
    }
}
