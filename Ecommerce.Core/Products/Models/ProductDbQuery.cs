using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Products.Models
{
    public class ProductDbQuery: PagedQuery
    {
        public string SearchText { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? BrandId { get; set; }
    }
}
