namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Karton",
                c => new
                    {
                        KartonID = c.Int(nullable: false, identity: true),
                        PregledID = c.Int(nullable: false),
                        PacijentID = c.Int(nullable: false),
                        Izvestaj = c.Int(),
                    })
                .PrimaryKey(t => t.KartonID)
                .ForeignKey("dbo.Pacijent", t => t.PacijentID, cascadeDelete: true)
                .ForeignKey("dbo.Pregled", t => t.PregledID, cascadeDelete: true)
                .Index(t => t.PregledID)
                .Index(t => t.PacijentID);
            
            CreateTable(
                "dbo.Pacijent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        Ime = c.String(nullable: false, maxLength: 50),
                        DatumRegistracije = c.DateTime(nullable: false),
                        Firma = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pregled",
                c => new
                    {
                        PregledID = c.Int(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.PregledID);
            
            CreateTable(
                "dbo.LekarPregled",
                c => new
                    {
                        LekarPregledID = c.Int(nullable: false, identity: true),
                        LekarID = c.Int(nullable: false),
                        PregledID = c.Int(nullable: false),
                        Participacija = c.Int(),
                    })
                .PrimaryKey(t => t.LekarPregledID)
                .ForeignKey("dbo.Lekar", t => t.LekarID, cascadeDelete: true)
                .ForeignKey("dbo.Pregled", t => t.PregledID, cascadeDelete: true)
                .Index(t => t.LekarID)
                .Index(t => t.PregledID);
            
            CreateTable(
                "dbo.Lekar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Prezime = c.String(nullable: false, maxLength: 50),
                        Ime = c.String(nullable: false, maxLength: 50),
                        DatumZaposlenja = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LekarPregled", "PregledID", "dbo.Pregled");
            DropForeignKey("dbo.LekarPregled", "LekarID", "dbo.Lekar");
            DropForeignKey("dbo.Karton", "PregledID", "dbo.Pregled");
            DropForeignKey("dbo.Karton", "PacijentID", "dbo.Pacijent");
            DropIndex("dbo.LekarPregled", new[] { "PregledID" });
            DropIndex("dbo.LekarPregled", new[] { "LekarID" });
            DropIndex("dbo.Karton", new[] { "PacijentID" });
            DropIndex("dbo.Karton", new[] { "PregledID" });
            DropTable("dbo.Lekar");
            DropTable("dbo.LekarPregled");
            DropTable("dbo.Pregled");
            DropTable("dbo.Pacijent");
            DropTable("dbo.Karton");
        }
    }
}
