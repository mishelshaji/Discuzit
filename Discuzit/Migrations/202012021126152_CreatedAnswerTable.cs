namespace Discuzit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAnswerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Body = c.String(maxLength: 2000),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        QuestionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "UserId" });
            DropTable("dbo.Answers");
        }
    }
}
