namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProgramDirecteds");
            DropIndex("dbo.ProgramDirecteds", "DirectedID");
           //DropForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.OptionalDirecteds");
            //DropColumn("dbo.ProgramDirecteds", "DirectedID");
           // ;
           // DropColumn("dbo.OptionalDirecteds", "DirectedID");
            ////AddColumn("dbo.ProgramDirecteds", "OptionalDirectedID", c => c.Int(nullable: false));
            ////AddColumn("dbo.OptionalDirecteds", "OptionalDirectedID", c => c.Int(nullable: false, identity: true));
            ////CreateIndex("dbo.ProgramDirecteds", "OptionalDirectedID");
            ////CreateIndex("dbo.OptionalDirecteds", "OptionalDirectedID");
            ////AddPrimaryKey("dbo.OptionalDirecteds", "OptionalDirectedID");
            ////AddPrimaryKey("dbo.ProgramDirecteds", new[] { "ProgramStructureID", "OptionalDirectedID" });
            ////AddForeignKey("dbo.ProgramDirecteds", "OptionalDirectedID", "dbo.OptionalDirecteds", "OptionalDirectedID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OptionalDirecteds", "DirectedID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.OptionalDirecteds");
            DropPrimaryKey("dbo.OptionalDirecteds");
            DropColumn("dbo.OptionalDirecteds", "OptionalDirectedID");
            AddPrimaryKey("dbo.OptionalDirecteds", "DirectedID");
            AddForeignKey("dbo.ProgramDirecteds", "DirectedID", "dbo.OptionalDirecteds", "DirectedID");
        }
    }
}
