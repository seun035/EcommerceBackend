using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.UIApiServices.Brands;
using Ecommerce.UIApiServices.Brands.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandComposerService _brandComposerService;

        public BrandsController(IBrandComposerService brandComposerService)
        {
            _brandComposerService = brandComposerService;
        }

        [HttpGet()]
        public async Task<IList<BrandViewModel>> GetBrands()
        {
            return await _brandComposerService.GetBrandsAsync();
        }
    }
}