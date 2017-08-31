namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update2 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.OptionalDirected", newName: "Directeds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Directeds", newName: "OptionalDirected");
        }
    }
}
