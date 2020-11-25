using API.Models;
using Domain.DBContext;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.ShoppingCartDecorator.DecoratorClasses
{
    public class MusicCategoryDecorator : ShoppingCartBaseDecorator
    {
        public MusicCategoryDecorator(IShoppingCart shoppingCart) : base(shoppingCart)
        {

        }

        public override void AddProduct(AddToShoppingCartModel model)
        {
            base.AddProduct(model);
        }

        public override string CheckAddingRules(AddToShoppingCartModel model)
        {
            string checkFromBase = base.CheckAddingRules(model);
            if (!string.IsNullOrEmpty(checkFromBase))
                return checkFromBase;

            using (var ctx = new DataContext())
            {
                bool isMusicType = ctx.Products.AsNoTracking()
                                                .Where(x => x.ProductId == model.ProductId)
                                                .Select(x => x.ProductType)
                                                .Single() == ProductTypes.Music;
                if (!isMusicType)
                    return "Ürün türü müzik olan bir sepete sadece müzik kategorisinde bir ürün eklenebilir.";

            }
            return string.Empty;
        }
    }
}
