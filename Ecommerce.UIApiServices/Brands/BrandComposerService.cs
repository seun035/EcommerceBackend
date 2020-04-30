using AutoMapper;
using Ecommerce.Core.Brands;
using Ecommerce.UIApiServices.Brands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UIApiServices.Brands
{
    public class BrandComposerService: IBrandComposerService
    {
        private readonly IBrandManager _brandManager;
        private readonly IMapper _mapper;

        public BrandComposerService(IBrandManager brandManager, IMapper mapper)
        {
            _brandManager = brandManager;
            _mapper = mapper;
        }

        public async Task<IList<BrandViewModel>> GetBrandsAsync()
        {
            var brands = await _brandManager.GetBrandsAsync();
            var viewModel = _mapper.Map<IList<BrandViewModel>>(brands);

            return viewModel;
        }
    }

    public interface IBrandComposerService
    {
        Task<IList<BrandViewModel>> GetBrandsAsync();
    }
}
