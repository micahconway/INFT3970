namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrerequisiteCourses", "PrerequisiteCourseName");
        }
    }
}
