namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test24 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities");
            AddForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities", "UniversityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities");
            DropForeignKey("dbo.Degrees", "University_UniversityID", "dbo.Universities");
            DropIndex("dbo.Degrees", new[] { "University_UniversityID" });
            DropColumn("dbo.Degrees", "University_UniversityID");
            AddForeignKey("dbo.Degrees", "UniversityID", "dbo.Universities", "UniversityID", cascadeDelete: true);
        }
    }
}
