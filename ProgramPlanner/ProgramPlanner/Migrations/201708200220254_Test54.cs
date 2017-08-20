namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YearDegrees", "Units", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.YearDegrees", "Units");
        }
    }
}
