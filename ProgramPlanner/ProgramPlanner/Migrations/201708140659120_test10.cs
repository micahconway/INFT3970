namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test10 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Directeds", "CourseID");
        }
        
        public override void Down()
        {
        }
    }
}
