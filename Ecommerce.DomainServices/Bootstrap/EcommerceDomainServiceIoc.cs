using Ecommerce.Core.Brands;
using Ecommerce.Core.Categories;
using Ecommerce.Core.Products;
using Ecommerce.DomainServices.Brands;
using Ecommerce.DomainServices.Categories;
using Ecommerce.DomainServices.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DomainServices.Bootstrap
{
    public static class EcommerceDomainServiceIoc
    {
        public static IServiceCollection EcommerceDomainServiceDISetUp(this IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandManager, BrandManager>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
