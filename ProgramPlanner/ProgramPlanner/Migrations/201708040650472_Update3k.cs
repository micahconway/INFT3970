namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DegreeCoreSlots",
                c => new
                    {
                        DegreeCoreSlotID = c.Int(nullable: false, identity: true),
                        numOfOptions = c.Int(nullable: false),
                        YearDegree_YearDegreeID = c.Int(),
                    })
                .PrimaryKey(t => t.DegreeCoreSlotID)
                .ForeignKey("dbo.YearDegrees", t => t.YearDegree_YearDegreeID)
                .Index(t => t.YearDegree_YearDegreeID);
            
            AddColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int(nullable: false));
            AddColumn("dbo.OptionalCoreCourses", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlotID");
            CreateIndex("dbo.OptionalCoreCourses", "CourseID");
            AddForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots", "DegreeCoreSlotID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DegreeCoreSlots", "YearDegree_YearDegreeID", "dbo.YearDegrees");
            DropForeignKey("dbo.OptionalCoreCourses", "DegreeCoreSlotID", "dbo.DegreeCoreSlots");
            DropForeignKey("dbo.OptionalCoreCourses", "CourseID", "dbo.Courses");
            DropIndex("dbo.OptionalCoreCourses", new[] { "CourseID" });
            DropIndex("dbo.OptionalCoreCourses", new[] { "DegreeCoreSlotID" });
            DropIndex("dbo.DegreeCoreSlots", new[] { "YearDegree_YearDegreeID" });
            DropColumn("dbo.OptionalCoreCourses", "CourseID");
            DropColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID");
            DropTable("dbo.DegreeCoreSlots");
        }
    }
}
