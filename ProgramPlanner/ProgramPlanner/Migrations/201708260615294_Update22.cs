namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramStructures", "Email", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "Email" });
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.ProgramStructures", "UserID", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramStructures", "User_UserID", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "User_UserID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProgramStructures", "User_UserID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.ProgramStructures", "UserID");
            AddPrimaryKey("dbo.Users", "Email");
            RenameColumn(table: "dbo.ProgramStructures", name: "User_UserID", newName: "Email");
            CreateIndex("dbo.ProgramStructures", "Email");
            AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email", cascadeDelete: true);
        }
    }
}
