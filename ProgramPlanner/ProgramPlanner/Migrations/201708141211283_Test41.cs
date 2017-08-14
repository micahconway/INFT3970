namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudyAreaAbbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropForeignKey("dbo.StudyAreaAbbreviations", "AbbreviationID", "dbo.Abbreviations");
            AddForeignKey("dbo.StudyAreaAbbreviations", "StudyAreaID", "dbo.StudyAreas", "StudyAreaID", cascadeDelete: false);
            AddForeignKey("dbo.StudyAreaAbbreviations", "AbbreviationID", "dbo.Abbreviations", "AbbreviationID", cascadeDelete: false);
        }

        public override void Down()
        {
        }
    }
}
