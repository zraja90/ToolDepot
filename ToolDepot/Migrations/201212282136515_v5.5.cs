namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v55 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "CallBack", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUs", "CallBack");
        }
    }
}
