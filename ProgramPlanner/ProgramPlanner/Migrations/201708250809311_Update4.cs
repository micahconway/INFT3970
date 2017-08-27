namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "UniversityID" });
            DropIndex("dbo.Courses", new[] { "University_UniversityID" });
            //DropColumn("dbo.Courses", "UniversityID");
            //RenameColumn(table: "dbo.Courses", name: "University_UniversityID", newName: "UniversityID");
            //AddColumn("dbo.Courses", "Abbreviation_AbbreviationID", c => c.Int());
            AlterColumn("dbo.Courses", "UniversityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "UniversityID");
            //CreateIndex("dbo.Courses", "Abbreviation_AbbreviationID");
            //AddForeignKey("dbo.Courses", "Abbreviation_AbbreviationID", "dbo.Abbreviations", "AbbreviationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Abbreviation_AbbreviationID", "dbo.Abbreviations");
            DropIndex("dbo.Courses", new[] { "Abbreviation_AbbreviationID" });
            DropIndex("dbo.Courses", new[] { "UniversityID" });
            AlterColumn("dbo.Courses", "UniversityID", c => c.Int());
            DropColumn("dbo.Courses", "Abbreviation_AbbreviationID");
            RenameColumn(table: "dbo.Courses", name: "UniversityID", newName: "University_UniversityID");
            AddColumn("dbo.Courses", "UniversityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "University_UniversityID");
            CreateIndex("dbo.Courses", "UniversityID");
        }
    }
}
