namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas");
            DropIndex("dbo.Abbreviations", new[] { "StudyArea_StudyAreaID" });
            DropColumn("dbo.Abbreviations", "StudyArea_StudyAreaID");
        }

        public override void Down()
        {
        }
    }
}
