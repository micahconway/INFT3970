namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramStructures", "Email", "dbo.Users");
            AddColumn("dbo.ProgramStructures", "User_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProgramStructures", "User_Email");
            AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email");
            DropColumn("dbo.ProgramStructures", "UserID"); 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "User_Email" });
            DropColumn("dbo.ProgramStructures", "User_Email");
            AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email", cascadeDelete: true);
        }
    }
}
