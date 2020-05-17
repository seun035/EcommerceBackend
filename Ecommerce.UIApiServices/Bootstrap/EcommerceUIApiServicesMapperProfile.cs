using AutoMapper;
using Ecommerce.Core.Brands.Models;
using Ecommerce.Core.Categories.Models;
using Ecommerce.Core.Products.Models;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Ecommerce.UIApiServices.Brands.ViewModels;
using Ecommerce.UIApiServices.Categories.ViewModels;
using Ecommerce.UIApiServices.Products.ViewModels;
using Ecommerce.UIApiServices.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Bootstrap
{
    public class EcommerceUIApiServicesMapperProfile : Profile
    {
        public EcommerceUIApiServicesMapperProfile()
        {
            CreateMap<Brand, BrandViewModel>().ForMember(x => x.Description, y => y.Ignore());

            CreateMap<Category, CategoryViewModel>();

            CreateMap< Product, ProductViewModel>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name));

            CreateMap<Product, ProductDetailViewModel>()
                .ForMember(x => x.BrandName, y => y.MapFrom(z => z.Brand.Name))
                .ForMember(x => x.BrandDescription, y => y.MapFrom(z => z.Brand.Description));

            CreateMap<User, UserInfoViewModel>();

            CreateMap<IUserContext, UserContextViewModel>();
        }
    }
}
