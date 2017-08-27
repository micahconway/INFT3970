namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update29 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users");
            DropIndex("dbo.ProgramStructures", new[] { "User_Email" });
            AlterColumn("dbo.ProgramStructures", "User_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProgramStructures", "User_Email");
            AddForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users", "Email");
        }
    }
}
