namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAddedDateFromSize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sizes", "AddedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sizes", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
