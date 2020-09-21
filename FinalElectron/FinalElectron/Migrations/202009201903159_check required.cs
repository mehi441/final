namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Note", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Note", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
