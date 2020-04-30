using Ecommerce.Core.Categories;
using Ecommerce.Core.Categories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryService _categoryService;

        public CategoryManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _categoryService.GetCategoriesAsync();
        }
    }
}
