namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update10 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "AbbreviationID" });
            DropIndex("dbo.Courses", new[] { "Abbreviation_AbbreviationID" });
            //DropColumn("dbo.Courses", "AbbreviationID");
            //RenameColumn(table: "dbo.Courses", name: "Abbreviation_AbbreviationID", newName: "AbbreviationID");
            AlterColumn("dbo.Courses", "AbbreviationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "AbbreviationID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "AbbreviationID" });
            AlterColumn("dbo.Courses", "AbbreviationID", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "AbbreviationID", newName: "Abbreviation_AbbreviationID");
            AddColumn("dbo.Courses", "AbbreviationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Abbreviation_AbbreviationID");
            CreateIndex("dbo.Courses", "AbbreviationID");
        }
    }
}
