namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.File", "PacijentID", "dbo.Pacijent");
            DropIndex("dbo.File", new[] { "PacijentID" });
            RenameColumn(table: "dbo.File", name: "Lekar_ID", newName: "LekarID");
            RenameIndex(table: "dbo.File", name: "IX_Lekar_ID", newName: "IX_LekarID");
            AlterColumn("dbo.File", "PacijentID", c => c.Int());
            CreateIndex("dbo.File", "PacijentID");
            AddForeignKey("dbo.File", "PacijentID", "dbo.Pacijent", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "PacijentID", "dbo.Pacijent");
            DropIndex("dbo.File", new[] { "PacijentID" });
            AlterColumn("dbo.File", "PacijentID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.File", name: "IX_LekarID", newName: "IX_Lekar_ID");
            RenameColumn(table: "dbo.File", name: "LekarID", newName: "Lekar_ID");
            CreateIndex("dbo.File", "PacijentID");
            AddForeignKey("dbo.File", "PacijentID", "dbo.Pacijent", "ID", cascadeDelete: true);
        }
    }
}
