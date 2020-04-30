using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.ShoppingCarts.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
