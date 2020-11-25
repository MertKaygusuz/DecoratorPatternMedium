using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DbClasses
{
    public class UserShoppingCarts
    {
        [Key]
        public int UserShoppingCartsId { get; set; }

        public ProductTypes ProductType { get; set; }

        public string UserId { get; set; }

        public Users User { get; set; }

        public ICollection<ProductsInShoppingCarts> ProductsInShoppingCarts { get; set; }
    }
}
