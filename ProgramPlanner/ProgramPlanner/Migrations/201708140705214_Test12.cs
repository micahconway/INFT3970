namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Majors", "YearDegree_yearDegreeID");
            DropForeignKey("dbo.Majors", "YearDegreeID", "dbo.YearDegrees");
        }

        public override void Down()
        {
        }
    }
}
