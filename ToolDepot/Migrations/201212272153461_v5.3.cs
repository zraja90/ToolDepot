namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecs", "SpecType", c => c.String());
            AddColumn("dbo.ProductSpecs", "SpecName", c => c.String());
            DropColumn("dbo.ProductSpecs", "Specs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecs", "Specs", c => c.String());
            DropColumn("dbo.ProductSpecs", "SpecName");
            DropColumn("dbo.ProductSpecs", "SpecType");
        }
    }
}
