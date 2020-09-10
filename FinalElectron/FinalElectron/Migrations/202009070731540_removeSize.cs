namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOptions", "SizeId", "dbo.Sizes");
            DropIndex("dbo.ProductOptions", new[] { "SizeId" });
            DropColumn("dbo.ProductOptions", "SizeId");
            DropTable("dbo.Sizes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductOptions", "SizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductOptions", "SizeId");
            AddForeignKey("dbo.ProductOptions", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
        }
    }
}
