using Ecommerce.Core.ShoppingCarts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.ShoppingCarts
{
    public interface IShoppingCartService
    {
        Task<ShoppingCart> GetShoppingCartAsync(Guid? cartId);

        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart cart);

        Task DeleteShoppingCartAsync(Guid cartId);
    }
}
