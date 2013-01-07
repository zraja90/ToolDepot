namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        DisplayName = c.String(maxLength: 255),
                        Host = c.String(nullable: false, maxLength: 255),
                        Port = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        EnableSsl = c.Boolean(nullable: false),
                        UseDefaultCredentials = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        BccEmailAddresses = c.String(maxLength: 200),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EmailAccountId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QueuedEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        From = c.String(nullable: false, maxLength: 500),
                        FromName = c.String(maxLength: 500),
                        To = c.String(nullable: false, maxLength: 500),
                        ToName = c.String(maxLength: 500),
                        CC = c.String(maxLength: 500),
                        Bcc = c.String(maxLength: 500),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        SentTries = c.Int(nullable: false),
                        SentOnUtc = c.DateTime(),
                        EmailAccountId = c.Int(nullable: false),
                        EmailName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailAccount", t => t.EmailAccountId, cascadeDelete: true)
                .Index(t => t.EmailAccountId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.QueuedEmail", new[] { "EmailAccountId" });
            DropForeignKey("dbo.QueuedEmail", "EmailAccountId", "dbo.EmailAccount");
            DropTable("dbo.QueuedEmail");
            DropTable("dbo.EmailTemplates");
            DropTable("dbo.EmailAccount");
        }
    }
}
