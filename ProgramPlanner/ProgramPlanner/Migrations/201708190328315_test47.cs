namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test47 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Code", c => c.String());
        }
    }
}
