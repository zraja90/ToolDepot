namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogLevelId = c.Int(nullable: false),
                        ShortMessage = c.String(nullable: false),
                        FullMessage = c.String(),
                        IpAddress = c.String(maxLength: 200),
                        UserId = c.Int(),
                        PageUrl = c.String(),
                        ReferrerUrl = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brochure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        Ordinal = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProductImage = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brochure");
            DropTable("dbo.Log");
        }
    }
}
