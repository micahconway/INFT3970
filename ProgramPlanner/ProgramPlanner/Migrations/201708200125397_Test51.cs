namespace ProgramPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test51 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MandatoryPrerquisites", newName: "AssumedKnowledge");
            RenameTable(name: "dbo.OptionalPrerequisites", newName: "AlternativeAssumedKnowledge");
            RenameColumn(table: "dbo.AssumedKnowledge", name: "PrerequisiteID", newName: "AssumedKnowledgeID");
            RenameColumn(table: "dbo.AlternativeAssumedKnowledge", name: "PrerequisiteID", newName: "AlternativeAKID");
            RenameIndex(table: "dbo.AssumedKnowledge", name: "IX_PrerequisiteID", newName: "IX_AssumedKnowledgeID");
            RenameIndex(table: "dbo.AlternativeAssumedKnowledge", name: "IX_PrerequisiteID", newName: "IX_AlternativeAKID");
            AddColumn("dbo.AlternativeAssumedKnowledge", "Prerequisite", c=> c.Int());
            AddColumn("dbo.AssumedKnowledge", "Prerequisite", c => c.Int());
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.AlternativeAssumedKnowledge", name: "IX_AlternativeAKID", newName: "IX_PrerequisiteID");
            RenameIndex(table: "dbo.AssumedKnowledge", name: "IX_AssumedKnowledgeID", newName: "IX_PrerequisiteID");
            RenameColumn(table: "dbo.AlternativeAssumedKnowledge", name: "AlternativeAKID", newName: "PrerequisiteID");
            RenameColumn(table: "dbo.AssumedKnowledge", name: "AssumedKnowledgeID", newName: "PrerequisiteID");
            RenameTable(name: "dbo.AlternativeAssumedKnowledge", newName: "OptionalPrerequisites");
            RenameTable(name: "dbo.AssumedKnowledge", newName: "MandatoryPrerquisites");
        }
    }
}
