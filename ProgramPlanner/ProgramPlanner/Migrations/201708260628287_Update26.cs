namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramStructures", "UserID", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "User_UserID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ProgramStructures", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Email");
            AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email");
            DropColumn("dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "User_Email" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ProgramStructures", "User_Email", c => c.Int());
            AddPrimaryKey("dbo.Users", "UserID");
            RenameColumn(table: "dbo.ProgramStructures", name: "User_Email", newName: "User_UserID");
            CreateIndex("dbo.ProgramStructures", "User_UserID");
            AddForeignKey("dbo.ProgramStructures", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
