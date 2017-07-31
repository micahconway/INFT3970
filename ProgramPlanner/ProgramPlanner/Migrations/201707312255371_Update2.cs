namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degrees", "UniversityID", c => c.Int(nullable: false));
            AddColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int(nullable: false));
            AddColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.Majors", "YearDegree_yearDegreeID", c => c.Int());
            CreateIndex("dbo.Degrees", "UniversityID");
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
            CreateIndex("dbo.Majors", "YearDegree_yearDegreeID");
            AddForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities", "UniversityID", cascadeDelete: true);
            AddForeignKey("dbo.Majors", "YearDegree_yearDegreeID", "dbo.YearDegrees", "yearDegreeID");
            AddForeignKey("dbo.YearDegrees", "Majors_MajorID", "dbo.Majors", "MajorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearDegrees", "Majors_MajorID", "dbo.Majors");
            DropForeignKey("dbo.Majors", "YearDegree_yearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities");
            DropIndex("dbo.Majors", new[] { "YearDegree_yearDegreeID" });
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            DropIndex("dbo.Degrees", new[] { "UniversityID" });
            DropColumn("dbo.Majors", "YearDegree_yearDegreeID");
            DropColumn("dbo.Majors", "YearDegreeID");
            DropColumn("dbo.YearDegrees", "Majors_MajorID");
            DropColumn("dbo.Degrees", "UniversityID");
        }
    }
}
