namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update291 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.ProgramStructures", name: "UserID", newName: "Email");
            //RenameIndex(table: "dbo.ProgramStructures", name: "IX_UserID", newName: "IX_Email");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProgramStructures", name: "IX_Email", newName: "IX_UserID");
            RenameColumn(table: "dbo.ProgramStructures", name: "Email", newName: "UserID");
        }
    }
}
