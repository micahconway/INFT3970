namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Degrees", new[] { "UniversityID" });
            DropIndex("dbo.Degrees", new[] { "University_UniversityID" });
            //DropColumn("dbo.Degrees", "UniversityID");
            //RenameColumn(table: "dbo.Degrees", name: "University_UniversityID", newName: "UniversityID");
            AlterColumn("dbo.Degrees", "UniversityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Degrees", "UniversityID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Degrees", new[] { "UniversityID" });
            AlterColumn("dbo.Degrees", "UniversityID", c => c.Int());
            RenameColumn(table: "dbo.Degrees", name: "UniversityID", newName: "University_UniversityID");
            AddColumn("dbo.Degrees", "UniversityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Degrees", "University_UniversityID");
            CreateIndex("dbo.Degrees", "UniversityID");
        }
    }
}
