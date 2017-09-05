namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31Aug2017Update1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DegreeCores", new[] { "YearDegree_YearDegreeID" });
            //CreateIndex("dbo.DegreeCores", "YearDegreeID");
           // AlterColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: true));
            //RenameTable(name: "dbo.Directeds", newName: "OptionalDirected");
            DropForeignKey("dbo.Directeds", "MajorID", "dbo.Majors");
            DropIndex("dbo.Directeds", new[] { "MajorID" });
            DropColumn("dbo.Directeds", "MajorID");
            CreateTable(
                "dbo.DirectedSlots",
                c => new
                    {
                        DirectedSlotID = c.Int(nullable: false, identity: true),
                        rule = c.String(),
                        MajorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirectedSlotID)
                .ForeignKey("dbo.Majors", t => t.MajorID)
                .Index(t => t.MajorID);
            
            AddColumn("dbo.Directeds", "DirectedSlotID", c => c.Int(nullable: false));
            //AlterColumn("dbo.Courses", "ReplacementID", c => c.Int(nullable: false));
            CreateIndex("dbo.Directeds", "DirectedSlotID");
            AddForeignKey("dbo.Directeds", "DirectedSlotID", "dbo.DirectedSlots", "DirectedSlotID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OptionalDirected", "MajorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OptionalDirected", "DirectedSlotID", "dbo.DirectedSlots");
            DropForeignKey("dbo.DirectedSlots", "MajorID", "dbo.Majors");
            DropIndex("dbo.DirectedSlots", new[] { "MajorID" });
            DropIndex("dbo.OptionalDirected", new[] { "DirectedSlotID" });
            AlterColumn("dbo.Courses", "ReplacementID", c => c.Int());
            DropColumn("dbo.OptionalDirected", "DirectedSlotID");
            DropTable("dbo.DirectedSlots");
            CreateIndex("dbo.OptionalDirected", "MajorID");
            AddForeignKey("dbo.Directeds", "MajorID", "dbo.Majors", "MajorID", cascadeDelete: true);
            RenameTable(name: "dbo.OptionalDirected", newName: "Directeds");
        }
    }
}
