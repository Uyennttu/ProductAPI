using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext (DbContextOptions<ProductAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductAPI.Models.Product> Product { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2, Name ="Seed 2", Description="Seed 2", Price = 20, Stock=200
                },
                 new Product
                 {
                     Id = 3,
                     Name = "Seed 3",
                     Description = "Seed 3",
                     Price = 30,
                     Stock = 300
                 }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id =1, FirstName="First Name", LastName= "Last Name", Position="CEO", Salary=100000});
        }
    }
}
