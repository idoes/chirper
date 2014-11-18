namespace Chirper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    
    public partial class SecurityQuestions2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SecurityQuestionOne", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "SecurityQuestionTwo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "SecurityQuestionThree", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "SecurityAnswerOne", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "SecurityAnswerTwo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "SecurityAnswerThree", c => c.String(nullable: false, maxLength: 50));

        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SecurityAnswerThree");
            DropColumn("dbo.AspNetUsers", "SecurityAnswerTwo");
            DropColumn("dbo.AspNetUsers", "SecurityAnswerOne");
            DropColumn("dbo.AspNetUsers", "SecurityQuestionThree");
            DropColumn("dbo.AspNetUsers", "SecurityQuestionTwo");
        }
    }
}
