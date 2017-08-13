namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13Aug2017Update2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramElectives");
            AddPrimaryKey("dbo.ProgramElectives", new[] { "CourseID", "ProgramStructureID" });
            DropColumn("dbo.ProgramElectives", "ProgramElectiveID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramElectives", "ProgramElectiveID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ProgramElectives");
            AddPrimaryKey("dbo.ProgramElectives", new[] { "ProgramElectiveID", "CourseID", "ProgramStructureID" });
        }
    }
}
