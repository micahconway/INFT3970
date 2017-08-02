namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2c : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.YearDegrees", "YearDegreeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YearDegrees", "YearDegreeName", c => c.String());
        }
    }
}
