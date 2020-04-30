using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.ShoppingCarts;
using Ecommerce.Core.ShoppingCarts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public Task<ShoppingCart> GetShoppingCart([FromQuery]Guid? cartId)
        {
            return _shoppingCartService.GetShoppingCartAsync(cartId);
        }

        [HttpPut]
        public Task<ShoppingCart> UpdateShoppingCart(ShoppingCart cart)
        {
            return _shoppingCartService.UpdateShoppingCartAsync(cart);
        }

        [HttpDelete("{cartId}")]
        public Task DeleteShoppingCart(Guid cartId)
        {
            return _shoppingCartService.DeleteShoppingCartAsync(cartId);
        }
    }
}