namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.File", "Lekar_ID", c => c.Int());
            CreateIndex("dbo.File", "Lekar_ID");
            AddForeignKey("dbo.File", "Lekar_ID", "dbo.Lekar", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "Lekar_ID", "dbo.Lekar");
            DropIndex("dbo.File", new[] { "Lekar_ID" });
            DropColumn("dbo.File", "Lekar_ID");
        }
    }
}
