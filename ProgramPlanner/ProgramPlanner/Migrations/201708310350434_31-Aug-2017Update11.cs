namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update11 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.ProgramDirecteds", name: "DirectedID", newName: "OptionalDirectedID");
            //RenameIndex(table: "dbo.ProgramDirecteds", name: "IX_DirectedID", newName: "IX_OptionalDirectedID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProgramDirecteds", name: "IX_OptionalDirectedID", newName: "IX_DirectedID");
            RenameColumn(table: "dbo.ProgramDirecteds", name: "OptionalDirectedID", newName: "DirectedID");
        }
    }
}
