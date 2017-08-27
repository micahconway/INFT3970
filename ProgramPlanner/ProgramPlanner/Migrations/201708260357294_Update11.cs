namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update11 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.YearDegrees", new[] { "DegreeID" });
            DropIndex("dbo.YearDegrees", new[] { "Degree_DegreeID" });
            //DropColumn("dbo.YearDegrees", "DegreeID");
            //RenameColumn(table: "dbo.YearDegrees", name: "Degree_DegreeID", newName: "DegreeID");
            AlterColumn("dbo.YearDegrees", "DegreeID", c => c.Int(nullable: false));
            CreateIndex("dbo.YearDegrees", "DegreeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.YearDegrees", new[] { "DegreeID" });
            AlterColumn("dbo.YearDegrees", "DegreeID", c => c.Int());
            RenameColumn(table: "dbo.YearDegrees", name: "DegreeID", newName: "Degree_DegreeID");
            AddColumn("dbo.YearDegrees", "DegreeID", c => c.Int(nullable: false));
            CreateIndex("dbo.YearDegrees", "Degree_DegreeID");
            CreateIndex("dbo.YearDegrees", "DegreeID");
        }
    }
}
