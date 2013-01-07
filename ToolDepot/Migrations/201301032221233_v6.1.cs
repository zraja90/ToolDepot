namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v61 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductReviews", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductReviews", "Rating", c => c.Int(nullable: false));
        }
    }
}
