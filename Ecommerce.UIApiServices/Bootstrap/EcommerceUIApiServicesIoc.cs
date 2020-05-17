using AutoMapper;
using Ecommerce.UIApiServices.Brands;
using Ecommerce.UIApiServices.Categories;
using Ecommerce.UIApiServices.Categories.ViewModels;
using Ecommerce.UIApiServices.Products;
using Ecommerce.UIApiServices.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ecommerce.UIApiServices.Bootstrap
{
    public static class EcommerceUIApiServicesIoc
    {
        public static IServiceCollection EcommerceUIApiServicesDISetUp(this IServiceCollection services)
        {
            services.AddScoped<IProductComposerService, ProductComposerService>();
            services.AddScoped<IBrandComposerService, BrandComposerService>();
            services.AddScoped<ICategoryComposerService, CategoryComposerService>();
            services.AddScoped<IUserComposerService, UserComposerService>();

            services.AddAutoMapper(typeof(EcommerceUIApiServicesMapperProfile));

            return services;
        }
    }
}
