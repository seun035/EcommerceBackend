using Ecommerce.UIApiServices.Brands.ViewModels;
using Ecommerce.UIApiServices.Categories.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Products.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public string Description { get; set; }

        //public BrandViewModel Brand { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
