using Ecommerce.Core.Auths;
using Ecommerce.Core.Brands;
using Ecommerce.Core.Categories;
using Ecommerce.Core.Products;
using Ecommerce.Core.Users;
using Ecommerce.DomainServices.Accounts;
using Ecommerce.DomainServices.Brands;
using Ecommerce.DomainServices.Categories;
using Ecommerce.DomainServices.Products;
using Ecommerce.DomainServices.Users;
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
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
