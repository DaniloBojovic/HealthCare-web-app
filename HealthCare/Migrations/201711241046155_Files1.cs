namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.File", "FileName", c => c.String(maxLength: 255));
            AlterColumn("dbo.File", "ContentType", c => c.String(maxLength: 100));
            DropColumn("dbo.File", "FileIme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.File", "FileIme", c => c.String());
            AlterColumn("dbo.File", "ContentType", c => c.String());
            DropColumn("dbo.File", "FileName");
        }
    }
}
