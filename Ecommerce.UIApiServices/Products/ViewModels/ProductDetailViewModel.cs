using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Products.ViewModels
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public string BrandDescription { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
