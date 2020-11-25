using System;
using System.Collections.Generic;
using System.Text;
using Domain.DbClasses;
using Domain.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.DBContext
{
    public partial class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseInMemoryDatabase(databaseName: "Test");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductsInShoppingCarts>()
                .HasKey(k => new { k.ProductId, k.UserShoppingCartsId });
           builder.Entity<ProductsInShoppingCarts>()
                .HasOne(k => k.Products)
                .WithMany(a => a.ProductsInShoppingCarts)
                .HasForeignKey(k => k.ProductId);
            builder.Entity<ProductsInShoppingCarts>()
                .HasOne(k => k.UserShoppingCarts)
                .WithMany(b => b.ProductsInShoppingCarts)
                .HasForeignKey(k => k.UserShoppingCartsId);

            builder.Entity<Users>()
                .HasMany(c => c.UserShoppingCarts)
                .WithOne(d => d.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Seed();
        }

    }
}
