namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Courses", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities");
            DropPrimaryKey("dbo.Universities");
            AlterColumn("dbo.Universities", "UniversityID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Universities", "UniversityID");
            AddForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities", "UniversityID");
            AddForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities", "UniversityID");
            AddForeignKey("dbo.Courses", "UniversityID", "dbo.Universities", "UniversityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities");
            DropPrimaryKey("dbo.Universities");
            AlterColumn("dbo.Universities", "UniversityID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Universities", "UniversityID");
            AddForeignKey("dbo.StudyAreas", "UniversityID", "dbo.Universities", "UniversityID");
            AddForeignKey("dbo.Courses", "UniversityID", "dbo.Universities", "UniversityID");
            AddForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities", "UniversityID");
        }
    }
}
