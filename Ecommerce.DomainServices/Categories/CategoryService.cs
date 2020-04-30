using Ecommerce.Core.Categories;
using Ecommerce.Core.Categories.Models;
using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.FindAllAsync();
        }
    }
}
