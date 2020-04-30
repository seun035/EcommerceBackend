using Ecommerce.Core.Common;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Products;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Products
{
    public class ProductManager : IProductManager
    {
        private readonly IProductService _productService;

        public ProductManager(IProductService productService)
        {
            _productService = productService;
        }

        public Task<Guid> CreateProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetProductsWithBrandCategory()
        {
            return await _productService.GetProductsWithBrandCategoryAsync();
        }

        public async Task<Product> GetProductWithBrandCategory(Guid productId)
        {
            ArgumentGuard.NotEmpty(productId, nameof(productId));

            // canview product

            return await _productService.GetProductWithBrandCategoryAsync(productId);
        }

        public Task<Paged<Product>> SearchAsync(ProductQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));

            return _productService.SearchAsync(query);
        }
    }
}
