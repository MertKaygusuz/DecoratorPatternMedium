using API.ShoppingCartDecorator.ConcreteClasses;
using API.ShoppingCartDecorator.DecoratorClasses;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.ShoppingCartDecorator.CreationalLogic
{
    public static class CreateShoppingCartWithType
    {
        public static IShoppingCart CreateShoppingCart(this ProductTypes type)
        {
            if (type == ProductTypes.Sport)
                return new SportCategoryDecorator(new GeneralShoppingCart());
            else if (type == ProductTypes.Music)
                return new MusicCategoryDecorator(new GeneralShoppingCart());
            else
                return new GeneralShoppingCart();
        }
    }
}
