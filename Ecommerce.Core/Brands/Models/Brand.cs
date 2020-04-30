using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Brands.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
