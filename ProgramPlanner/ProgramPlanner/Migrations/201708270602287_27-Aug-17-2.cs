namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27Aug172 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Majors", new[] { "YearDegreeID" });
            AlterColumn("dbo.Majors", "YearDegreeID", c => c.Int());
            RenameColumn(table: "dbo.Majors", name: "YearDegreeID", newName: "YearDegree_YearDegreeID");
            AddColumn("dbo.Majors", "YearDegreeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Majors", "YearDegree_YearDegreeID");
            CreateIndex("dbo.Majors", "YearDegreeID");
        }
    }
}
