using Ecommerce.Core.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Categories
{
    public interface ICategoryManager
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}
