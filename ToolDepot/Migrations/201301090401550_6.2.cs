namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _62 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductReviews", "IsApproved", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductReviews", "IsApproved", c => c.Boolean(nullable: false));
        }
    }
}
