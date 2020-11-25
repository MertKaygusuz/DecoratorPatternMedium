using Domain.DbClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DBContext
{
    public partial class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<UserShoppingCarts> UserShoppingCarts { get; set; }

        public DbSet<ProductsInShoppingCarts> ProductsInShoppingCarts { get; set; }

        public DbSet<Products> Products { get; set; }
    }
}
