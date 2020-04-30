using Ecommerce.Core.Common;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Products
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(Product product);

        Task<Product> GetProductWithBrandCategoryAsync(Guid productId);

        Task<IList<Product>> GetProductsWithBrandCategoryAsync();

        Task<Paged<Product>> SearchAsync(ProductQuery query);
    }
}
