namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisReadytoorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsReady", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsReady");
        }
    }
}
