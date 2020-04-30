using AutoMapper;
using Ecommerce.Core.Categories;
using Ecommerce.UIApiServices.Categories.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UIApiServices.Categories
{
    public class CategoryComposerService : ICategoryComposerService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryComposerService(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        public async Task<IList<CategoryViewModel>> GetCategoriesAsync()
        {
           var categories = await _categoryManager.GetCategoriesAsync();

            var viewModel = _mapper.Map<IList<CategoryViewModel>>(categories);
            return viewModel;
        }
    }

    public interface ICategoryComposerService
    {
        Task<IList<CategoryViewModel>> GetCategoriesAsync();
    }
}
