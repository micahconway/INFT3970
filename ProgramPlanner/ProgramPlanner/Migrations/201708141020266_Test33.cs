namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            CreateTable(
                "dbo.Abbreviations",
                c => new
                    {
                        AbbreviationID = c.Int(nullable: false, identity: true),
                        AbbrevName = c.String(),
                        StudyAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AbbreviationID)
                .ForeignKey("dbo.StudyAreas", t => t.StudyAreaID, cascadeDelete: false)
                .Index(t => t.StudyAreaID);
            
            CreateTable(
                "dbo.StudyAreas",
                c => new
                    {
                        StudyAreaID = c.Int(nullable: false, identity: true),
                        StudyAreaName = c.String(),
                        UniversityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudyAreaID)
                .ForeignKey("dbo.Universities", t => t.UniversityID, cascadeDelete: false)
                .Index(t => t.UniversityID);
            
            AddColumn("dbo.Courses", "AbbreviationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "AbbreviationID");
            AddForeignKey("dbo.Courses", "AbbreviationID", "dbo.Abbreviations", "AbbreviationID");
            DropColumn("dbo.Courses", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CategoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Courses", "AbbreviationID", "dbo.Abbreviations");
            DropForeignKey("dbo.Abbreviations", "StudyAreaID", "dbo.StudyAreas");
            DropIndex("dbo.Courses", new[] { "AbbreviationID" });
            DropIndex("dbo.StudyAreas", new[] { "UniversityID" });
            DropIndex("dbo.Abbreviations", new[] { "StudyAreaID" });
            DropColumn("dbo.Courses", "AbbreviationID");
            DropTable("dbo.StudyAreas");
            DropTable("dbo.Abbreviations");
            CreateIndex("dbo.Courses", "CategoryID");
            AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
