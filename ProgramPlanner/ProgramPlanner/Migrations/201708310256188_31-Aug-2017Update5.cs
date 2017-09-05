namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OptionalDirected", newName: "OptionalDirecteds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OptionalDirecteds", newName: "OptionalDirected");
        }
    }
}
