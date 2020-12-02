using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WmTestProject.Domain.Entities;

namespace WmTestProject.DataAccess
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category1", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Category2", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Category3", CreatedAt = DateTime.Now }
            };

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Id = 1, Name = "Manufacturer1", CreatedAt = DateTime.Now },
                new Manufacturer { Id = 2, Name = "Manufacturer2", CreatedAt = DateTime.Now },
                new Manufacturer { Id = 3, Name = "Manufacturer3", CreatedAt = DateTime.Now }
            };

            var suppliers = new List<Supplier>
            {
                new Supplier { Id = 1, Name = "Supplier1", CreatedAt = DateTime.Now },
                new Supplier { Id = 2, Name = "Supplier2", CreatedAt = DateTime.Now },
                new Supplier { Id = 3, Name = "Supplier3", CreatedAt = DateTime.Now }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description 1234",
                    Price = 346M,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    SupplierId = 1,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description 1234",
                    Price = 400M,
                    CategoryId = 2,
                    ManufacturerId = 2,
                    SupplierId = 2,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description 1234",
                    Price = 100M,
                    CategoryId = 3,
                    ManufacturerId = 3,
                    SupplierId = 3,
                    CreatedAt = DateTime.Now
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Manufacturer>().HasData(manufacturers);
            modelBuilder.Entity<Supplier>().HasData(suppliers);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
