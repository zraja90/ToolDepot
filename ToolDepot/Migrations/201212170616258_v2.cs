namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IsFeaturedCategory = c.Boolean(nullable: false),
                        CategoryImage = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductSpecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Specs = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Feature = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductFeatures", new[] { "ProductId" });
            DropIndex("dbo.ProductSpecs", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropForeignKey("dbo.ProductFeatures", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductSpecs", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.ProductCategory");
            DropTable("dbo.ProductFeatures");
            DropTable("dbo.ProductSpecs");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
        }
    }
}
