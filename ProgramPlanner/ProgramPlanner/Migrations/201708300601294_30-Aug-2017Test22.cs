namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test22 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramDirecteds");
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID", "Completed" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgramDirecteds");
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "DirectedID" });
        }
    }
}
