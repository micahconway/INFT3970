namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2a : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            AlterColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int());
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            AlterColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int(nullable: false));
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
        }
    }
}
