namespace Chirper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cheeps",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(maxLength: 180),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cheeps", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Cheeps", new[] { "AuthorId" });
            DropTable("dbo.Cheeps");
        }
    }
}
