namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4h : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Degrees", "DegreeName", c => c.String(nullable: false));
            AlterColumn("dbo.Majors", "MajorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Majors", "MajorName", c => c.String());
            AlterColumn("dbo.Degrees", "DegreeName", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            AlterColumn("dbo.Courses", "CourseCode", c => c.String());
        }
    }
}
