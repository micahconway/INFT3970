namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DegreeCores",
                c => new
                    {
                        DegreeCoreID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        YearDegreeID = c.Int(nullable: false),
                        YearDegree_YearDegreeID = c.Int(),
                    })
                .PrimaryKey(t => t.DegreeCoreID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.YearDegrees", t => t.YearDegree_YearDegreeID)
                .Index(t => t.CourseID)
                .Index(t => t.YearDegree_YearDegreeID);
            
            AddColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID", c => c.Int());
            CreateIndex("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
            AddForeignKey("dbo.YearDegrees", "DegreeCores_DegreeCoreID", "dbo.DegreeCores", "DegreeCoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearDegrees", "DegreeCores_DegreeCoreID", "dbo.DegreeCores");
            DropForeignKey("dbo.DegreeCores", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.DegreeCores", "CourseID", "dbo.Courses");
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            DropIndex("dbo.DegreeCores", new[] { "CourseID" });
            DropIndex("dbo.YearDegrees", new[] { "DegreeCores_DegreeCoreID" });
            DropColumn("dbo.YearDegrees", "DegreeCores_DegreeCoreID");
            DropTable("dbo.DegreeCores");
        }
    }
}
