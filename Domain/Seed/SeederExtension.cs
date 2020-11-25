using Domain.DbClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Seed
{
    public static class SeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData
                (
                    new Users
                    {
                        Name = "Mert",
                        Surname = "Kaygusuz",
                        UserId = "MK"
                    },
                    new Users
                    {
                        Name = "Mire",
                        Surname = "Chatman",
                        UserId = "MC"
                    },
                    new Users
                    {
                        Name = "Deron",
                        Surname = "Williams",
                        UserId = "DW"
                    },
                    new Users
                    {
                        Name = "Khalid El",
                        Surname = "Amin",
                        UserId = "KEA"
                    }
                );

            modelBuilder.Entity<Products>().HasData
                (
                    new Products
                    {
                        ProductId = 1,
                        ProductName = "40.5 cm Tekneli Oyma Kısa Sap Dut Bağlama",
                        CountInInventory = 5,
                        ProductType = Enums.ProductTypes.Music,
                        Color = "Altın Sarısı"
                    },
                     new Products
                     {
                         ProductId = 2,
                         ProductName = "41 cm Tekneli Yaprak Kısa Sap Maun Bağlama",
                         CountInInventory = 6,
                         ProductType = Enums.ProductTypes.Music,
                         Color = "Kahverengi"
                     },
                      new Products
                      {
                          ProductId = 3,
                          ProductName = "Profesyonel Tenis Raketi",
                          CountInInventory = 1,
                          ProductType = Enums.ProductTypes.Sport,
                          Color = "Belirtilmemiş"
                      },
                       new Products
                       {
                           ProductId = 4,
                           ProductName = "Pinpon Topu",
                           CountInInventory = 500,
                           ProductType = Enums.ProductTypes.Sport,
                           Color = "Beyaz"
                       },
                        new Products
                        {
                            ProductId = 5,
                            ProductName = "İsviçre Çakısı",
                            CountInInventory = 0,
                            ProductType = Enums.ProductTypes.General,
                            Color = "Belirtilmemiş"
                        }
                );

            modelBuilder.Entity<UserShoppingCarts>().HasData
                (
                    new UserShoppingCarts
                    {
                       UserShoppingCartsId = 1,
                       UserId = "MK",
                       ProductType = Enums.ProductTypes.General
                    },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 2,
                        UserId = "MK",
                        ProductType = Enums.ProductTypes.Music
                    },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 3,
                        UserId = "MK",
                        ProductType = Enums.ProductTypes.Sport
                    },
                     new UserShoppingCarts
                     {
                         UserShoppingCartsId = 4,
                         UserId = "MC",
                         ProductType = Enums.ProductTypes.General
                     },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 5,
                        UserId = "MC",
                        ProductType = Enums.ProductTypes.Music
                    },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 6,
                        UserId = "MC",
                        ProductType = Enums.ProductTypes.Sport
                    },
                     new UserShoppingCarts
                     {
                         UserShoppingCartsId = 7,
                         UserId = "DW",
                         ProductType = Enums.ProductTypes.General
                     },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 8,
                        UserId = "DW",
                        ProductType = Enums.ProductTypes.Music
                    },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 9,
                        UserId = "DW",
                        ProductType = Enums.ProductTypes.Sport
                    },
                     new UserShoppingCarts
                     {
                         UserShoppingCartsId = 10,
                         UserId = "KEA",
                         ProductType = Enums.ProductTypes.General
                     },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 11,
                        UserId = "KEA",
                        ProductType = Enums.ProductTypes.Music
                    },
                    new UserShoppingCarts
                    {
                        UserShoppingCartsId = 12,
                        UserId = "KEA",
                        ProductType = Enums.ProductTypes.Sport
                    }


                );

            modelBuilder.Entity<ProductsInShoppingCarts>().HasData
               (
                   new ProductsInShoppingCarts
                   {
                       ProductId = 1,
                       UserShoppingCartsId = 1,
                       ProductsCount = 1
                   }
               );
        }
    }
}
