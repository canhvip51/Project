﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SHOESSHOPEntities : DbContext
    {
        public SHOESSHOPEntities()
            : base("name=SHOESSHOPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BanList> BanLists { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportUnit> ImportUnits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImg> ProductImgs { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TypeSho> TypeShoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }
    }
}
