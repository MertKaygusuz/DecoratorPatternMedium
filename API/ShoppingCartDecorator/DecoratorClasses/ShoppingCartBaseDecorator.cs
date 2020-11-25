using API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.ShoppingCartDecorator.DecoratorClasses
{
    public abstract class ShoppingCartBaseDecorator : IShoppingCart
    {
        protected IShoppingCart shoppingCart;

        public ShoppingCartBaseDecorator(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public virtual void AddProduct(AddToShoppingCartModel model)
        {
            shoppingCart.AddProduct(model);
        }

        public virtual string CheckAddingRules(AddToShoppingCartModel model)
        {
            return shoppingCart.CheckAddingRules(model);
        }
    }
}
