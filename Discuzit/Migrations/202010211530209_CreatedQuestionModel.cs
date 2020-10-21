namespace Discuzit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedQuestionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 70),
                        Body = c.String(nullable: false),
                        TotalAnswers = c.Int(nullable: false),
                        TotalUpVotes = c.Int(nullable: false),
                        TotalDownVotes = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.Title);
            
            AddColumn("dbo.Categories", "Category_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Category_Id");
            AddForeignKey("dbo.Categories", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropColumn("dbo.Categories", "Category_Id");
            DropTable("dbo.Questions");
        }
    }
}
