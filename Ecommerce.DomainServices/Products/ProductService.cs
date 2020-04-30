using Ecommerce.Core.Common;
using Ecommerce.Core.Data;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Products;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _poductRepository;

        public ProductService(IProductRepository poductRepository)
        {
            _poductRepository = poductRepository;
        }

        public Task<Guid> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetProductsWithBrandCategoryAsync()
        {
            var products = await _poductRepository.FindProductsWithBrandCartegoryAsync();
            return products;
        }

        public async Task<Product> GetProductWithBrandCategoryAsync(Guid productId)
        {
            ArgumentGuard.NotEmpty(productId, nameof(productId));

            var product = await _poductRepository.GetProductWithBrandCartegoryAsync(productId);

            return product;
        }

        public Task<Paged<Product>> SearchAsync(ProductQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));

            var dbQuery = ToDbQuery(query);

            var searchResult = _poductRepository.SearchAsync(dbQuery);
            return searchResult;
        }

        private ProductDbQuery ToDbQuery(ProductQuery query)
        {
            return new ProductDbQuery
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                SearchText = query.SearchText,
                CategoryId = query.CategoryId,
                BrandId = query.BrandId
            };
        }
    }
}
