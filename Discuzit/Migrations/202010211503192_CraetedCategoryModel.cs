namespace Discuzit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CraetedCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CategoryName, unique:true);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
