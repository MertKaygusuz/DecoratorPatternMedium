using API.Models;
using API.ShoppingCartDecorator;
using API.ShoppingCartDecorator.CreationalLogic;
using Domain.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.ModelStateWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers.ShoppingCartProsesses
{
    [ApiController]
    [Route("[controller]")]
    public class AddToCartController : ControllerBase
    {
        private DataContext _context;
        public AddToCartController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(AddToShoppingCartModel model)
        {
            //EF Core inmemory veritabanını entegre etmek için yazıldı
            _context.Database.EnsureCreated();

            var cartType = _context.UserShoppingCarts.AsNoTracking()
                                                        .Where(x => x.UserShoppingCartsId == model.UserShoppingCartId)
                                                        .Select(x => x.ProductType)
                                                        .Single();

            IShoppingCart shoppingCart = cartType.CreateShoppingCart();

            //veritabanı kaydından önce kontroller çalıştırılıyor.
            string error = shoppingCart.CheckAddingRules(model);
            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            //sepete ekleme işlemi gerçekleştiriliyor.
            shoppingCart.AddProduct(model);

            //işlemler sonucunda veritabanındaki değişiklikleri görmek isterseniz
            //aşağıdaki kod bloğunu aktif hale getirip 55. satıra break point yerleştirdikten sonra listeleri inceleyebilirsiniz
            /*
            var productList = _context.Products.AsNoTracking().ToList();
            var userList = _context.Users.AsNoTracking().ToList();
            var userShoppingCartList = _context.UserShoppingCarts.AsNoTracking().ToList();
            var productsInShoppingCartsList = _context.ProductsInShoppingCarts.AsNoTracking().ToList();
            */

            return Ok("İşleminiz başarıyla gerçekleşti");
        }
    }
}
