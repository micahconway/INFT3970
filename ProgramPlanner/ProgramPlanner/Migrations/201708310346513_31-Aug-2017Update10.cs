namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update10 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramDirecteds", new[] { "DirectedID" });
            DropColumn("dbo.ProgramDirecteds", "DirectedID");
        }

        public override void Down()
        {
        }
    }
}
