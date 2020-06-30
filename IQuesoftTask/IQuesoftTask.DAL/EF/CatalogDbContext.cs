using IQuesoftTask.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace IQuesoftTask.DAL.EF
{
    public class CatalogDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public CatalogDbContext() : base("ShopCatalog")
        {
        }
        static CatalogDbContext()
        {
            Database.SetInitializer<CatalogDbContext>(new CatalogInitializer());
        }
        public CatalogDbContext(string connectionString)
            : base(connectionString)
        {
        }
        public class CatalogInitializer : DropCreateDatabaseAlways<CatalogDbContext>
        {
            DateTime dateManufacture1 = new DateTime(2020, 01, 12);
            DateTime dateManufacture2 = new DateTime(2020, 02, 22);
            DateTime dateManufacture3 = new DateTime(2020, 03, 12);
            DateTime datePurchase1 = new DateTime(2020, 04, 12);
            DateTime datePurchase2 = new DateTime(2020, 04, 12);
            DateTime datePurchase3 = new DateTime(2020, 05, 22);
            DateTime datePurchase4 = new DateTime(2020, 06, 12);
            protected override void Seed(CatalogDbContext context)
            {
                var branch1 = new Branch
                {
                    Id = 1,
                    Country = "Germany",
                    Town = "Berlin",
                    Address = "Unter den Linden 63-65"
                };

                var branch2 = new Branch
                {
                    Id = 2,
                    Country = "France",
                    Town = "Paris",
                    Address = "48 Boulevard Jourdan"
                };

                context.Branches.AddRange(new List<Branch> { branch1, branch2 });
                context.SaveChanges();

                var product1 = new Product
                {
                    Id = 1,
                    Name = "Samsung Galaxy A40",
                    DateManufacture = dateManufacture1,
                    ManufacturerName = "Samsung",
                    Branch = branch1,
                    BranchId = branch1.Id,
                    Price = 5000
                };

                var product2 = new Product
                {
                    Id = 2,
                    Name = "Samsung Galaxy Z Flip 8",
                    DateManufacture = dateManufacture2,
                    ManufacturerName = "Samsung",
                    Price = 6000,
                    Branch = branch2,
                    BranchId = branch2.Id
                };
                var product3 = new Product
                {
                    Id = 3,
                    Name = "Xiaomi Redmi Note 8T 4/64GB Dual Sim Starscape Blue",
                    DateManufacture = dateManufacture3,
                    ManufacturerName = "Xiaomi",
                    Price = 7000,
                    Branch = branch2,
                    BranchId = branch2.Id
                };

                context.Products.AddRange(new List<Product> { product1, product2, product3 });
                context.SaveChanges();

                var seller1 = new Seller
                {
                    Id = 1,
                    FirstName = "Joan",
                    LastName = "Rowling",
                    Product = product1,
                    ProductId = product1.Id,
                    MonthRevenue = 0,
                    QuartalRevenue = 0
                };
                var seller2 = new Seller
                {
                    Id = 2,
                    FirstName = "David",
                    LastName = "Benioff",
                    Product = product2,
                    ProductId = product2.Id,
                    MonthRevenue = 0,
                    QuartalRevenue = 0
                };

                context.Sellers.AddRange(new List<Seller> { seller1, seller2 });
                context.SaveChanges();

                var purchase1 = new Purchase
                {
                    Id = 1,
                    PurchaseDate = datePurchase1,
                    Seller = seller1,
                    SellerId = seller1.Id,
                    Product = seller1.Product,
                    ProductId = seller1.ProductId

                };
                var purchase2 = new Purchase
                {
                    Id = 2,
                    PurchaseDate = datePurchase2,
                    Seller = seller2,
                    SellerId = seller2.Id,
                    Product = product1,
                    ProductId = product1.Id
                };
                purchase1.Seller.MonthRevenue = purchase1.Product.Price * 0.15m;
                purchase2.Seller.QuartalRevenue = purchase1.Product.Price * 0.15m;
                purchase1.Seller.MonthRevenue = purchase1.Product.Price * 0.15m;
                purchase2.Seller.QuartalRevenue = purchase2.Product.Price * 0.15m;

                purchase1.Product.Branch.MonthRevenue = purchase1.Product.Price * 0.15m;
                purchase2.Product.Branch.QuartalRevenue = purchase2.Product.Price * 0.15m;
                purchase1.Product.Branch.MonthRevenue = purchase1.Product.Price * 0.15m;
                purchase2.Product.Branch.QuartalRevenue = purchase2.Product.Price * 0.15m;

                context.Purchases.AddRange(new List<Purchase> { purchase1, purchase2 });
                context.SaveChanges();

            }
        }
    }
}
