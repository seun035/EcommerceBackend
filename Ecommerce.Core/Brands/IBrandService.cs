using Ecommerce.Core.Brands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Brands
{
    public interface IBrandService
    {
        Task<IList<Brand>> GetBrandsAsync();
    }
}
