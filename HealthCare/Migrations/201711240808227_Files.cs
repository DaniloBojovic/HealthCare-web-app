namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileIme = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PacijentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Pacijent", t => t.PacijentID, cascadeDelete: true)
                .Index(t => t.PacijentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "PacijentID", "dbo.Pacijent");
            DropIndex("dbo.File", new[] { "PacijentID" });
            DropTable("dbo.File");
        }
    }
}
