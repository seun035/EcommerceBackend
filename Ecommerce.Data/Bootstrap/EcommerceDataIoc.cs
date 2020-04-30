using Ecommerce.Core.Data;
using Ecommerce.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Bootstrap
{
    public static class EcommerceDataIoc
    {
        public static IServiceCollection EcommerceDataDISetUp(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
