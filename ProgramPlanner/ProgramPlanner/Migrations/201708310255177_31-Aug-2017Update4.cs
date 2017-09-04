namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Directeds", newName: "OptionalDirected");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OptionalDirected", newName: "Directeds");
        }
    }
}
