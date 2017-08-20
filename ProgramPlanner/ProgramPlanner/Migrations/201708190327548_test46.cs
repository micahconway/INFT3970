namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Code", c => c.String());
            DropColumn("dbo.Courses", "CourseCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseCode", c => c.String(nullable: false, maxLength: 8));
            DropColumn("dbo.Courses", "Code");
        }
    }
}
