namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MajorCores",
                c => new
                    {
                        MajorCoreID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        MajorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MajorCoreID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Majors", t => t.MajorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.MajorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MajorCores", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.MajorCores", "CourseID", "dbo.Courses");
            DropIndex("dbo.MajorCores", new[] { "MajorID" });
            DropIndex("dbo.MajorCores", new[] { "CourseID" });
            DropTable("dbo.MajorCores");
        }
    }
}
