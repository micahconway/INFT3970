namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test541 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.YearDegrees", name: "yearDegreeID", newName: "YearDegreeID");

        }

        public override void Down()
        {
        }
    }
}
