namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 150),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrandSocials", "BrandId", "dbo.Brands");
            DropIndex("dbo.BrandSocials", new[] { "BrandId" });
            DropTable("dbo.BrandSocials");
        }
    }
}
