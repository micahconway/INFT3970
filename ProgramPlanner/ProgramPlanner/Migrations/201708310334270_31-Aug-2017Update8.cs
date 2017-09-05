namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update8 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProgramDirecteds", "DirectedID");
            DropForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.Directeds");
            AddColumn("dbo.ProgramDirecteds", "OptionalDirectedID", c => c.Int(nullable: false));
            AddColumn("dbo.OptionalDirecteds", "OptionalDirectedID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramDirecteds", "OptionalDirectedID");
            CreateIndex("dbo.OptionalDirecteds", "OptionalDirectedID");
            DropPrimaryKey("dbo.OptionalDirecteds");
            AddPrimaryKey("dbo.OptionalDirecteds", "OptionalDirectedID");
            AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "OptionalDirectedID" });
            AddForeignKey("dbo.ProgramDirecteds", "OptionalDirectedID", "dbo.OptionalDirecteds", "OptionalDirectedID");
        }

        public override void Down()
        {
        }
    }
}
