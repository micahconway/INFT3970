namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30Aug2017Test14 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DegreeCores", new[] { "CourseID" });
            DropIndex("dbo.DegreeCores", new[] { "YearDegreeID" });
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            DropIndex("dbo.DegreeCores", new[] { "Course_CourseID" });
            //DropColumn("dbo.DegreeCores", "CourseID");
            //DropColumn("dbo.DegreeCores", "YearDegreeID");
            //RenameColumn(table: "dbo.DegreeCores", name: "Course_CourseID", newName: "CourseID");
            //RenameColumn(table: "dbo.DegreeCores", name: "YearDegree_YearDegreeID", newName: "YearDegreeID");
            DropPrimaryKey("dbo.DegreeCores");
            AlterColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int(nullable: false));
            AlterColumn("dbo.DegreeCores", "CourseID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DegreeCores", new[] { "CourseID", "YearDegreeID" });
            CreateIndex("dbo.DegreeCores", "CourseID");
            CreateIndex("dbo.DegreeCores", "YearDegreeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DegreeCores", new[] { "YearDegreeID" });
            DropIndex("dbo.DegreeCores", new[] { "CourseID" });
            DropPrimaryKey("dbo.DegreeCores");
            AlterColumn("dbo.DegreeCores", "CourseID", c => c.Int());
            AlterColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int());
            AddPrimaryKey("dbo.DegreeCores", new[] { "CourseID", "YearDegreeID" });
            RenameColumn(table: "dbo.DegreeCores", name: "YearDegreeID", newName: "YearDegree_YearDegreeID");
            RenameColumn(table: "dbo.DegreeCores", name: "CourseID", newName: "Course_CourseID");
            AddColumn("dbo.DegreeCores", "YearDegreeID", c => c.Int(nullable: false));
            AddColumn("dbo.DegreeCores", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.DegreeCores", "Course_CourseID");
            CreateIndex("dbo.DegreeCores", "YearDegree_YearDegreeID");
            CreateIndex("dbo.DegreeCores", "YearDegreeID");
            CreateIndex("dbo.DegreeCores", "CourseID");
        }
    }
}
