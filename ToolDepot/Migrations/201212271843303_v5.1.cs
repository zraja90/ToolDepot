namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "IsFeatured", c => c.Boolean());
        }
    }
}
