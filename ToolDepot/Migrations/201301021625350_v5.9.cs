namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v59 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairAppt", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairAppt", "PhoneNumber");
        }
    }
}
