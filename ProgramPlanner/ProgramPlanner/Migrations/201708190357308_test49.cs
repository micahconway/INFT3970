namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test49 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudyAreaAbbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropForeignKey("dbo.StudyAreaAbbreviations", "AbbreviationID", "dbo.Abbreviations");
            DropIndex("dbo.StudyAreaAbbreviations", new[] { "StudyAreaID" });
            DropIndex("dbo.StudyAreaAbbreviations", new[] { "AbbreviationID" });
            AddColumn("dbo.Abbreviations", "StudyAreaID", c => c.Int(nullable: false));
            AddColumn("dbo.Abbreviations", "StudyArea_StudyAreaID", c => c.Int());
            CreateIndex("dbo.Abbreviations", "StudyAreaID");
            CreateIndex("dbo.Abbreviations", "StudyArea_StudyAreaID");
            AddForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas", "StudyAreaID");
            AddForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas", "StudyAreaID");
            DropTable("dbo.StudyAreaAbbreviations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudyAreaAbbreviations",
                c => new
                    {
                        StudyAreaID = c.Int(nullable: false),
                        AbbreviationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudyAreaID, t.AbbreviationID });
            
            DropForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas");
            DropIndex("dbo.Abbreviations", new[] { "StudyArea_StudyAreaID" });
            DropIndex("dbo.Abbreviations", new[] { "StudyAreaID" });
            DropColumn("dbo.Abbreviations", "StudyArea_StudyAreaID");
            DropColumn("dbo.Abbreviations", "StudyAreaID");
            CreateIndex("dbo.StudyAreaAbbreviations", "AbbreviationID");
            CreateIndex("dbo.StudyAreaAbbreviations", "StudyAreaID");
            AddForeignKey("dbo.StudyAreaAbbreviations", "AbbreviationID", "dbo.Abbreviations", "AbbreviationID", cascadeDelete: true);
            AddForeignKey("dbo.StudyAreaAbbreviations", "StudyAreaID", "dbo.StudyAreas", "StudyAreaID", cascadeDelete: true);
        }
    }
}
