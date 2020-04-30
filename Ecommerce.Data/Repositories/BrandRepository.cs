using Ecommerce.Core.Brands.Models;
using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Repositories
{
    public class BrandRepository: DataRepository<Brand>, IBrandRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public BrandRepository(EcommerceDbContext dbContext)
            :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
