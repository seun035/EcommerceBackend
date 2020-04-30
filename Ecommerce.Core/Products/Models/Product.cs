using Ecommerce.Core.Brands.Models;
using Ecommerce.Core.Categories.Models;
using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Products.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }

        public DateTime? DeletedDateUtc { get; set; }
    }
}
