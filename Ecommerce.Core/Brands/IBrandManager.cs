using Ecommerce.Core.Brands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Brands
{
    public interface IBrandManager
    {
        Task<IList<Brand>> GetBrandsAsync();
    }
}
