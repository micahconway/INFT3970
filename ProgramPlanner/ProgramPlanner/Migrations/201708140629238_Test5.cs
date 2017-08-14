namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramStructures", new[] { "User_Email" });
            DropForeignKey("dbo.ProgramStructures", "User_Email", "dbo.Users");
            DropColumn("dbo.ProgramStructures", "User_Email");
            AddColumn("dbo.ProgramStructures", "Email", c => c.String(nullable: false, maxLength: 128));
            AddForeignKey("dbo.ProgramStructures", "Email", "dbo.Users", "Email", cascadeDelete: false);
            CreateIndex("dbo.ProgramStructures", "Email");

        }

        public override void Down()
        {
        }
    }
}
