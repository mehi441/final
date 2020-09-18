namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductOptions", t => t.ProductOptionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductOptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Wishlists", "ProductOptionId", "dbo.ProductOptions");
            DropIndex("dbo.Wishlists", new[] { "ProductOptionId" });
            DropIndex("dbo.Wishlists", new[] { "UserId" });
            DropTable("dbo.Wishlists");
        }
    }
}
