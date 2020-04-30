using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Common;
using Ecommerce.Core.Products.Models;
using Ecommerce.UIApiServices.Products;
using Ecommerce.UIApiServices.Products.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductComposerService _productComposerService;

        public ProductsController(IProductComposerService productComposerService)
        {
            _productComposerService = productComposerService;
        }

        [HttpGet("{productId:Guid}")]
        public async Task<ProductDetailViewModel> GetProductInfo(Guid productId)
        {
            return await _productComposerService.GetProductWithBrandCategoryAsync(productId);
        }

        [HttpGet()]
        public async Task<IList<ProductViewModel>> GetProducts()
        {
            return await _productComposerService.GetProductsWithBrandCategoryAsync();
        }

        [HttpGet("_search")]
        public async Task<Paged<ProductViewModel>> Search([FromQuery] ProductQuery query)
        {
            return await _productComposerService.SearchAsync(query);
        }
    }
}