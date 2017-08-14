namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test34 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities");
            AddColumn("dbo.Abbreviations", "StudyArea_StudyAreaID", c => c.Int());
            AlterColumn("dbo.Abbreviations", "AbbrevName", c => c.String(nullable: false));
            AlterColumn("dbo.StudyAreas", "StudyAreaName", c => c.String(nullable: false));
            CreateIndex("dbo.Abbreviations", "StudyArea_StudyAreaID");
            AddForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas", "StudyAreaID");
            AddForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas", "StudyAreaID");
            AddForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities", "UniversityID");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            DropForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Abbreviations", "StudyArea_StudyAreaID", "dbo.StudyAreas");
            DropForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropIndex("dbo.Abbreviations", new[] { "StudyArea_StudyAreaID" });
            AlterColumn("dbo.StudyAreas", "StudyAreaName", c => c.String());
            AlterColumn("dbo.Abbreviations", "AbbrevName", c => c.String());
            DropColumn("dbo.Abbreviations", "StudyArea_StudyAreaID");
            AddForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities", "UniversityID", cascadeDelete: true);
            AddForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas", "StudyAreaID", cascadeDelete: true);
        }
    }
}
