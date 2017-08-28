namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27Aug20175 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.OptionalCoreCourses", new[] { "DegreeCoreSlotID" });
            AlterColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int());
            RenameColumn(table: "dbo.OptionalCoreCourses", name: "DegreeCoreSlotID", newName: "DegreeCoreSlot_DegreeCoreSlotID");
            AddColumn("dbo.OptionalCoreCourses", "DegreeCoreSlotID", c => c.Int(nullable: false));
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlot_DegreeCoreSlotID");
            CreateIndex("dbo.OptionalCoreCourses", "DegreeCoreSlotID");
        }
    }
}
