using Ecommerce.Core.ShoppingCarts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.ShoppingCarts
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartAsync(Guid? cartId);

        Task DeleteCartAsync(Guid cartId);

        Task<ShoppingCart> UpdateCartAsync(ShoppingCart cart); 
    }
}
