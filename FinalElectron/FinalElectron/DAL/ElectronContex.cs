﻿using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalElectron.DAL
{
    public class ElectronContex:DbContext
    {
        public ElectronContex() : base("ElectronCon")
        {

        }
         
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdSlide> AdSlides { get; set; }
        public DbSet<AdFooter> AdFooters { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<BrandSocial> BrandSocials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<HotDeal> HotDeals { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }


    }
}