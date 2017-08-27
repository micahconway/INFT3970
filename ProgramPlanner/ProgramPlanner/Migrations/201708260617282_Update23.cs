namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update23 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProgramStructures", "Email");
            AlterColumn("dbo.ProgramStructures", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramStructures", "UserID");
            AddForeignKey("dbo.ProgramStructures", "UserID", "dbo.Users", "UserID", cascadeDelete: false);
        }

        public override void Down()
        {
        }
    }
}
