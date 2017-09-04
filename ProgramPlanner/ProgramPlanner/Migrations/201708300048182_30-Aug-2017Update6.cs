namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Update6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "ReplacementID" });
            DropColumn("dbo.Courses", "ReplacementID");
            DropForeignKey("dbo.Courses", "ReplacementID");
            AddColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: true));
            CreateIndex("dbo.Courses", "ReplacementID");
            AddForeignKey("dbo.Courses", "ReplacementID", "dbo.Replacements", "ReplacementID", cascadeDelete: true);
        }

        public override void Down()
        {
        }
    }
}
