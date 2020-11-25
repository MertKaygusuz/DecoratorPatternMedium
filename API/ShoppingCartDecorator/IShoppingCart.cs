using API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.ShoppingCartDecorator
{
    public interface IShoppingCart
    {
        string CheckAddingRules(AddToShoppingCartModel model);

        void AddProduct(AddToShoppingCartModel model);
    }
}
