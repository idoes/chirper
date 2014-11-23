namespace Chirper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheepNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cheeps", "Text", c => c.String(nullable: false, maxLength: 180));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cheeps", "Text", c => c.String(maxLength: 180));
        }
    }
}
