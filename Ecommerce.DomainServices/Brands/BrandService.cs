using Ecommerce.Core.Brands;
using Ecommerce.Core.Brands.Models;
using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IList<Brand>> GetBrandsAsync()
        {
            return await _brandRepository.FindAllAsync();
        }
    }
}
