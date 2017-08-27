namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Abbreviations", new[] { "StudyAreaID" });
            DropIndex("dbo.Abbreviations", new[] { "StudyArea_StudyAreaID" });
            //DropColumn("dbo.Abbreviations", "StudyAreaID");
            //RenameColumn(table: "dbo.Abbreviations", name: "StudyArea_StudyAreaID", newName: "StudyAreaID");
            AlterColumn("dbo.Abbreviations", "StudyAreaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Abbreviations", "StudyAreaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Abbreviations", new[] { "StudyAreaID" });
            AlterColumn("dbo.Abbreviations", "StudyAreaID", c => c.Int());
            RenameColumn(table: "dbo.Abbreviations", name: "StudyAreaID", newName: "StudyArea_StudyAreaID");
            AddColumn("dbo.Abbreviations", "StudyAreaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Abbreviations", "StudyArea_StudyAreaID");
            CreateIndex("dbo.Abbreviations", "StudyAreaID");
        }
    }
}
