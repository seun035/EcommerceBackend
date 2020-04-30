using Ecommerce.Core.Categories.Models;
using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Repositories
{
    public class CategoryRepository: DataRepository<Category>, ICategoryRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public CategoryRepository(EcommerceDbContext dbContext)
            :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
