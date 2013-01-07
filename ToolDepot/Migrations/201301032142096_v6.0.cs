namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v60 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        Location = c.String(),
                        Rating = c.Int(nullable: false),
                        ReviewTitle = c.String(),
                        Review = c.String(),
                        Recommend = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductReviews", new[] { "ProductId" });
            DropForeignKey("dbo.ProductReviews", "ProductId", "dbo.Product");
            DropTable("dbo.ProductReviews");
        }
    }
}
