namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YearDegrees", "YearDegreeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.YearDegrees", "YearDegreeName");
        }
    }
}
