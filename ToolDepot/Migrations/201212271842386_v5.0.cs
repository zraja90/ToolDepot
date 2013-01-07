namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "IsFeatured", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "IsFeatured", c => c.Boolean(nullable: false));
        }
    }
}
