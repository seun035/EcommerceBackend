using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.ShoppingCarts.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }

        public IList<CartItem> CartItems { get; set; }
    }
}
