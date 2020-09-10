namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhoverimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "HoverImage", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "HoverImage");
        }
    }
}
