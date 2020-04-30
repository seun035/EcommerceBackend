using Ecommerce.Core.Common;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Data
{
    public interface IProductRepository: IDataRepository<Product>
    {
        Task<Product> GetProductWithBrandCartegoryAsync(Guid productId, bool allowNull = false);

        Task<IList<Product>> FindProductsWithBrandCartegoryAsync();

        Task<Paged<Product>> SearchAsync(ProductDbQuery dbQuery);
    }
}
