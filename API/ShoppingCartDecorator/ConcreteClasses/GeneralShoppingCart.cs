using API.Models;
using Domain.DbClasses;
using Domain.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.ShoppingCartDecorator.ConcreteClasses
{
    public class GeneralShoppingCart : IShoppingCart
    {
        public void AddProduct(AddToShoppingCartModel model)
        {
            using (var ctx = new DataContext())
            {
                //stoktan düşme işlemi
                var product = ctx.Products.Find(model.ProductId);
                product.CountInInventory -= (int)model.Count;

                //sepete ekleme işlemleri
                var productsInShoppingCarts = ctx.ProductsInShoppingCarts.Where(x => x.UserShoppingCartsId == model.UserShoppingCartId && x.ProductId == model.ProductId)
                                                                         .SingleOrDefault();

                if (productsInShoppingCarts == null)
                {
                    ProductsInShoppingCarts newProductInShoppingCarts = new ProductsInShoppingCarts
                    {
                        ProductId = (int)model.ProductId,
                        UserShoppingCartsId = (int)model.UserShoppingCartId,
                        ProductsCount = (int)model.Count
                    };

                    ctx.ProductsInShoppingCarts.Add(newProductInShoppingCarts);
                }
                else
                {
                    productsInShoppingCarts.ProductsCount += (int)model.Count;
                }

                ctx.SaveChanges();
            }
        }

        public string CheckAddingRules(AddToShoppingCartModel model)
        {
            const int maxCountInCart = 10;

            using (var ctx = new DataContext())
            {
                var productCountInInventory = ctx.Products.AsNoTracking()
                                                           .Where(x => x.ProductId == model.ProductId)
                                                           .SingleOrDefault();

                if (productCountInInventory == null)
                    return "Envanterimizde böyle bir ürün bulunmamaktadır.";
                else
                {
                    if(productCountInInventory.CountInInventory - model.Count < 0)
                        return $"Envanterimizde yeterli sayıda {model.ProductName} ürünü bulunmamaktadır.";
                }
                    

                int totalProductCountInCart = ctx.ProductsInShoppingCarts.AsNoTracking()
                                                                         .Where(x => x.UserShoppingCartsId == model.UserShoppingCartId && x.ProductId == model.ProductId)
                                                                         .Sum(x => (int?)x.ProductsCount) ?? 0;

                if (model.Count + totalProductCountInCart > maxCountInCart)
                    return $"Sepetinize en fazla {maxCountInCart} adet ürün ekleyebilirsiniz";

            }
            return string.Empty;
        }
    }
}
