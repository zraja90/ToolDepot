namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v58 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairAppt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        ToolName = c.String(),
                        RepairDescription = c.String(nullable: false),
                        ScheduledTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RepairAppt");
        }
    }
}
