namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v56 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EmailAccount", "ProgramId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailAccount", "ProgramId", c => c.Int(nullable: false));
        }
    }
}
