using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DbClasses
{
    public class ProductsInShoppingCarts
    {
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public int UserShoppingCartsId { get; set; }
        public UserShoppingCarts UserShoppingCarts { get; set; }

        public int ProductsCount { get; set; }
    }
}
