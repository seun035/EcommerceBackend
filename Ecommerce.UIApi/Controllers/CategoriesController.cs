using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.UIApiServices.Categories;
using Ecommerce.UIApiServices.Categories.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryComposerService _categoryComposerService;

        public CategoriesController(ICategoryComposerService categoryComposerService )
        {
            _categoryComposerService = categoryComposerService;
        }

        [HttpGet()]
        public async Task<IList<CategoryViewModel>> GetCategories()
        {
            return await  _categoryComposerService.GetCategoriesAsync();
        }
    }
}