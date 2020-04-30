using AutoMapper;
using Ecommerce.Core.Common;
using Ecommerce.Core.Products;
using Ecommerce.Core.Products.Models;
using Ecommerce.UIApiServices.Products.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UIApiServices.Products
{
    public class ProductComposerService : IProductComposerService
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductComposerService(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        public async Task<IList<ProductViewModel>> GetProductsWithBrandCategoryAsync()
        {
            var products = await _productManager.GetProductsWithBrandCategory();
            return _mapper.Map<IList<ProductViewModel>>(products);
        }

        public async Task<ProductDetailViewModel> GetProductWithBrandCategoryAsync(Guid productId)
        {
            var product = await _productManager.GetProductWithBrandCategory(productId);
            return _mapper.Map<ProductDetailViewModel>(product);
        }

        public async Task<Paged<ProductViewModel>> SearchAsync(ProductQuery query)
        {
            var result = await _productManager.SearchAsync(query);

            var viewModelItem = _mapper.Map<IList<ProductViewModel>>(result.Items);

            var viewModel = new Paged<ProductViewModel> { Items = viewModelItem, PageNumber = result.PageNumber, PageSize = result.PageSize, TotalCount = result.TotalCount };
            return viewModel;
        }

    }

    public interface IProductComposerService
    {
        Task<ProductDetailViewModel> GetProductWithBrandCategoryAsync(Guid productId);

        Task<IList<ProductViewModel>> GetProductsWithBrandCategoryAsync();

        Task<Paged<ProductViewModel>> SearchAsync(ProductQuery query);
    }
}
