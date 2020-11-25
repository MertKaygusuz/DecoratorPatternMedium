using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DbClasses
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(200)]
        public string ProductName { get; set; }

        public int CountInInventory { get; set; }

        public ProductTypes ProductType { get; set; }

        //öylesine eklenen bir alan, ürünle alakalı buna benzer çeşitli bilgiler eklenebilir
        [MaxLength(20)]
        public string Color { get; set; }

        public ICollection<ProductsInShoppingCarts> ProductsInShoppingCarts { get; set; }
    }
}
