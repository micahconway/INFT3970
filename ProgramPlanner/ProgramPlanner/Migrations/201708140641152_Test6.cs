namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DegreeCores", "YearDegree_YearDegreeID");
        }

        public override void Down()
        {
        }
    }
}
