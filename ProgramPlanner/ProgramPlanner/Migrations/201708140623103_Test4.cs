namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProgramStructures", "UserID");

        }

        public override void Down()
        {
        }
    }
}
