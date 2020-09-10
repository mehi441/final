namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 250),
                        AddedDate = c.DateTime(nullable: false),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Image = c.String(maxLength: 200),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        AddedDate = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BrandModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        IsSpecial = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BrandModels", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.SubCategoryId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, storeType: "money"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        OldPrice = c.Decimal(nullable: false, storeType: "money"),
                        AddedDate = c.DateTime(nullable: false),
                        ColorId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ColorId)
                .Index(t => t.SizeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HotDeals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EndDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ProductOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductOptions", t => t.ProductOptionId, cascadeDelete: true)
                .Index(t => t.ProductOptionId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, storeType: "money"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        ProductOptionId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductOptions", t => t.ProductOptionId, cascadeDelete: true)
                .Index(t => t.ProductOptionId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDelivered = c.Boolean(nullable: false),
                        IsFreeShipping = c.Boolean(nullable: false),
                        ShippingPrice = c.Decimal(nullable: false, storeType: "money"),
                        Note = c.String(nullable: false, maxLength: 1000),
                        PeymentMethod = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAddresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Company = c.String(maxLength: 150),
                        AddressFirst = c.String(nullable: false, maxLength: 250),
                        AddressSecond = c.String(maxLength: 250),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 15),
                        Country = c.String(nullable: false, maxLength: 50),
                        Region = c.String(nullable: false, maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 250),
                        IsNewsletter = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, maxLength: 100),
                        ProductOptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductOptions", t => t.ProductOptionId, cascadeDelete: true)
                .Index(t => t.ProductOptionId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Content = c.String(nullable: false, maxLength: 500),
                        Star = c.Byte(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false, maxLength: 40),
                        Enquiry = c.String(nullable: false, maxLength: 1000),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 40),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        OpenTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(nullable: false),
                        DiscountPercent = c.Int(nullable: false),
                        PoweredBy = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 20),
                        AddressFirst = c.String(nullable: false, maxLength: 150),
                        AddressSecond = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Image = c.String(maxLength: 200),
                        Link = c.String(nullable: false, maxLength: 500),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 200),
                        Content = c.String(nullable: false, maxLength: 400),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Specifications", "ProductOptionId", "dbo.ProductOptions");
            DropForeignKey("dbo.ProductOptions", "SizeId", "dbo.Sizes");
            DropForeignKey("dbo.ProductOptions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "ProductOptionId", "dbo.ProductOptions");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.UserAddresses");
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.HotDeals", "ProductOptionId", "dbo.ProductOptions");
            DropForeignKey("dbo.ProductOptions", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ModelId", "dbo.BrandModels");
            DropForeignKey("dbo.Descriptions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BrandModels", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Blogs", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Specifications", new[] { "ProductOptionId" });
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ProductOptionId" });
            DropIndex("dbo.HotDeals", new[] { "ProductOptionId" });
            DropIndex("dbo.ProductOptions", new[] { "ProductId" });
            DropIndex("dbo.ProductOptions", new[] { "SizeId" });
            DropIndex("dbo.ProductOptions", new[] { "ColorId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Descriptions", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ModelId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.BrandModels", new[] { "BrandId" });
            DropIndex("dbo.Blogs", new[] { "AdminId" });
            DropIndex("dbo.Admins", new[] { "Admin_Id" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.Partners");
            DropTable("dbo.Settings");
            DropTable("dbo.Newsletters");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Reviews");
            DropTable("dbo.Specifications");
            DropTable("dbo.Sizes");
            DropTable("dbo.Users");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.HotDeals");
            DropTable("dbo.Colors");
            DropTable("dbo.ProductOptions");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Products");
            DropTable("dbo.BrandModels");
            DropTable("dbo.Brands");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
        }
    }
}
