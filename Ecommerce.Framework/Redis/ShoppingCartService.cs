using Ecommerce.Core.Helpers;
using Ecommerce.Core.ShoppingCarts;
using Ecommerce.Core.ShoppingCarts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Framework.Redis
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(Guid? cartId)
        {
            return await _shoppingCartRepository.GetShoppingCartAsync(cartId);
        }

        public async Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart cart)
        {
            ArgumentGuard.NotNull(cart, nameof(cart));

            return await _shoppingCartRepository.UpdateCartAsync(cart);
        }

        public async Task DeleteShoppingCartAsync(Guid cartId)
        {
            ArgumentGuard.NotEmpty(cartId, nameof(cartId));

            await _shoppingCartRepository.DeleteCartAsync(cartId);
        }
    }
}
