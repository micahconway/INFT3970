namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses");
            AddForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.DegreeCores", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            DropColumn("dbo.DegreeCores", "YearDegree_YearDegreeID");
            AddForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.DegreeCores", "YearDegreeID", "dbo.YearDegrees", "YearDegreeID", cascadeDelete: true);
        }
    }
}
