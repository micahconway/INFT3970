namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3e : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NeededPrereqs", "NeededPrereqName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NeededPrereqs", "NeededPrereqName");
        }
    }
}
