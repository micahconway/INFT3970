namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13Aug2017Update1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "ProgramElectiveID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramElectives", new[] { "ProgramElectiveID", "CourseID", "ProgramStructureID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgramElectives");
            AlterColumn("dbo.ProgramElectives", "ProgramElectiveID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProgramElectives", "ProgramElectiveID");
        }
    }
}
