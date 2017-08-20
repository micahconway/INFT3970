namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test40 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudyAreaAbbreviations",
                c => new
                    {
                        StudyAreaID = c.Int(nullable: false),
                        AbbreviationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudyAreaID, t.AbbreviationID })
                .ForeignKey("dbo.StudyAreas", t => t.StudyAreaID, cascadeDelete: false)
                .ForeignKey("dbo.Abbreviations", t => t.AbbreviationID, cascadeDelete: false)
                .Index(t => t.StudyAreaID)
                .Index(t => t.AbbreviationID);            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abbreviations", "StudyArea_StudyAreaID", c => c.Int());
            DropForeignKey("dbo.StudyAreaAbbreviations", "AbbreviationID", "dbo.Abbreviations");
            DropForeignKey("dbo.StudyAreaAbbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropIndex("dbo.StudyAreaAbbreviations", new[] { "AbbreviationID" });
            DropIndex("dbo.StudyAreaAbbreviations", new[] { "StudyAreaID" });
            DropTable("dbo.StudyAreaAbbreviations");
            CreateIndex("dbo.Abbreviations", "StudyArea_StudyAreaID");
            AddForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas", "StudyAreaID");
        }
    }
}
