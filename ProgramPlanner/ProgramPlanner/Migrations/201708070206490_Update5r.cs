namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5r : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.YearDegrees", new[] { "DegreeCores_DegreeCoreID" });
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            AlterColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID", c => c.Int(nullable: false));
            AlterColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int(nullable: false));
            CreateIndex("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.YearDegrees", new[] { "Majors_MajorID" });
            DropIndex("dbo.YearDegrees", new[] { "DegreeCores_DegreeCoreID" });
            AlterColumn("dbo.YearDegrees", "Majors_MajorID", c => c.Int());
            AlterColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID", c => c.Int());
            CreateIndex("dbo.YearDegrees", "Majors_MajorID");
            CreateIndex("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
        }
    }
}
