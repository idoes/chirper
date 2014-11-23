namespace Chirper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerOne", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerTwo", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerThree", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerThree", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerTwo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "SecurityAnswerOne", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
