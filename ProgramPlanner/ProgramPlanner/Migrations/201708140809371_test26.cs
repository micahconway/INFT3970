namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "UniversityID", "dbo.Universities");
            AddForeignKey("dbo.Courses", "UniversityID", "dbo.Universities", "UniversityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "University_UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Courses", "UniversityID", "dbo.Universities");
            DropIndex("dbo.Courses", new[] { "University_UniversityID" });
            DropColumn("dbo.Courses", "University_UniversityID");
            AddForeignKey("dbo.Courses", "UniversityID", "dbo.Universities", "UniversityID", cascadeDelete: true);
        }
    }
}
