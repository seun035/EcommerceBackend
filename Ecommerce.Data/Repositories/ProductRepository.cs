using Ecommerce.Core.Common;
using Ecommerce.Core.Data;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Products.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : DataRepository<Product>, IProductRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ProductRepository(EcommerceDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Product>> FindProductsWithBrandCartegoryAsync()
        {
            return await _dbContext.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProductWithBrandCartegoryAsync(Guid productId, bool allowNull = false)
        {
            ArgumentGuard.NotEmpty(productId, nameof(productId));

            var entity = await _dbContext.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == productId);

            if (entity == null && !allowNull)
            {
                throw new ObjectNotFoundException($"No record found that matches the given Id {productId}");
            }

            return entity;
        }

        public async Task<Paged<Product>> SearchAsync(ProductDbQuery dbQuery)
        {
            ArgumentGuard.NotNull(dbQuery, nameof(dbQuery));

            var queryableResult = _dbContext.Products.Include(p => p.Brand).Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(dbQuery.SearchText))
            {
                queryableResult = queryableResult.Where(x => x.Name.Trim().ToLower().Contains(dbQuery.SearchText.Trim().ToLower()));
            }

            if (dbQuery.CategoryId.HasValue)
            {
                queryableResult = queryableResult.Where(x => x.Category.Id == dbQuery.CategoryId.Value);
            }

            if (dbQuery.BrandId.HasValue)
            {
                queryableResult = queryableResult.Where(x => x.Brand.Id == dbQuery.BrandId.Value);
            }

            var totalCount = queryableResult?.Count() ?? default(long);
            var results = await queryableResult.Skip(dbQuery.PageSize * (dbQuery.PageNumber - 1)).Take(dbQuery.PageSize).ToListAsync();

            return new Paged<Product> { PageSize = dbQuery.PageSize, PageNumber = dbQuery.PageNumber, TotalCount = totalCount, Items = results };
        }
    }
}
