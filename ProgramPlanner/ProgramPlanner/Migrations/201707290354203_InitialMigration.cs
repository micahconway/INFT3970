namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Units = c.Int(nullable: false),
                        UniversityID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UniversityID, cascadeDelete: true)
                .Index(t => t.UniversityID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        UniversityID = c.Int(nullable: false, identity: true),
                        UniName = c.String(),
                    })
                .PrimaryKey(t => t.UniversityID);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        MajorID = c.Int(nullable: false, identity: true),
                        MajorName = c.String(),
                    })
                .PrimaryKey(t => t.MajorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropIndex("dbo.Courses", new[] { "UniversityID" });
            DropTable("dbo.Majors");
            DropTable("dbo.Universities");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
