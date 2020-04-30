using Ecommerce.Core.Brands;
using Ecommerce.Core.Brands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Brands
{
    public class BrandManager : IBrandManager
    {
        private readonly IBrandService _brandService;

        public BrandManager(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IList<Brand>> GetBrandsAsync()
        {
            return await _brandService.GetBrandsAsync();
        }
    }
}
