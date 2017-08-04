namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directeds",
                c => new
                    {
                        DirectedID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        MajorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectedID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Majors", t => t.MajorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.MajorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Directeds", "MajorID", "dbo.Majors");
            DropForeignKey("dbo.Directeds", "CourseID", "dbo.Courses");
            DropIndex("dbo.Directeds", new[] { "MajorID" });
            DropIndex("dbo.Directeds", new[] { "CourseID" });
            DropTable("dbo.Directeds");
        }
    }
}
