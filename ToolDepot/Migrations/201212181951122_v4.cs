namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 128),
                        Email = c.String(maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        Avatar = c.String(),
                        TimeZoneId = c.String(),
                        ConfirmationToken = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        LastIpAddress = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        LastLoginDateUtc = c.DateTime(),
                        LastActivityDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        IsSystemRole = c.Boolean(nullable: false),
                        SystemName = c.String(),
                        IsGlobal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SystemName = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Seconds = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        StopOnError = c.Boolean(nullable: false),
                        LastStartUtc = c.DateTime(),
                        LastEndUtc = c.DateTime(),
                        LastSuccessUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord_Role_Mapping",
                c => new
                    {
                        CustomerRole_Id = c.Int(nullable: false),
                        PermissionRecord_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerRole_Id, t.PermissionRecord_Id })
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.PermissionRecord", t => t.PermissionRecord_Id, cascadeDelete: true)
                .Index(t => t.CustomerRole_Id)
                .Index(t => t.PermissionRecord_Id);
            
            CreateTable(
                "dbo.Customer_CustomerRole_Mapping",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        CustomerRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.CustomerRole_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRole_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.CustomerRole_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customer_CustomerRole_Mapping", new[] { "CustomerRole_Id" });
            DropIndex("dbo.Customer_CustomerRole_Mapping", new[] { "Customer_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "PermissionRecord_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "CustomerRole_Id" });
            DropForeignKey("dbo.Customer_CustomerRole_Mapping", "CustomerRole_Id", "dbo.CustomerRole");
            DropForeignKey("dbo.Customer_CustomerRole_Mapping", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "PermissionRecord_Id", "dbo.PermissionRecord");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "CustomerRole_Id", "dbo.CustomerRole");
            DropTable("dbo.Customer_CustomerRole_Mapping");
            DropTable("dbo.PermissionRecord_Role_Mapping");
            DropTable("dbo.ScheduleTask");
            DropTable("dbo.PermissionRecord");
            DropTable("dbo.CustomerRole");
            DropTable("dbo.Customer");
        }
    }
}
