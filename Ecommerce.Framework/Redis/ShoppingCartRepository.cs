using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.ShoppingCarts;
using Ecommerce.Core.ShoppingCarts.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Framework.Redis
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDatabase _redisDatabase;

        public ShoppingCartRepository(IConnectionMultiplexer redisConnectionMultiplexer)
        {
            _redisDatabase = redisConnectionMultiplexer.GetDatabase();
        }

        public async Task DeleteCartAsync(Guid cartId)
        {
            ArgumentGuard.NotEmpty(cartId, nameof(cartId));

            await _redisDatabase.KeyDeleteAsync(cartId.ToString());
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(Guid? cartId)
        {
            var result = default(RedisValue);

            if (cartId.HasValue)
            {
                result = await _redisDatabase.StringGetAsync(cartId.Value.ToString());

            }            

            if (result.IsNullOrEmpty)
            {
                var key = Guid.NewGuid();
                var cart = new ShoppingCart { Id = key, CartItems = new List<CartItem>() };
                await _redisDatabase.StringSetAsync(key.ToString(), JsonSerializer.Serialize(cart));

                return cart;
            }

            return JsonSerializer.Deserialize<ShoppingCart>(result);
        }

        public async Task<ShoppingCart> UpdateCartAsync(ShoppingCart cart)
        {
            ArgumentGuard.NotNull(cart, nameof(cart));

            var result = await _redisDatabase.StringGetAsync(cart.Id.ToString());

            if (result.IsNullOrEmpty)
            {
                throw new ObjectNotFoundException($"cart with id {cart.Id} does not exsist");
            }

            await _redisDatabase.StringSetAsync(cart.Id.ToString(), JsonSerializer.Serialize(cart));

            return cart;
        }
    }
}
