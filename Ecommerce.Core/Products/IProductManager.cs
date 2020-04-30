using Ecommerce.Core.Common;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Products
{
    public interface IProductManager
    {
        Task<Guid> CreateProductAsync();

        Task<Product> GetProductWithBrandCategory(Guid productId);

        Task<IList<Product>> GetProductsWithBrandCategory();

        Task<Paged<Product>> SearchAsync(ProductQuery query);
    }
}
