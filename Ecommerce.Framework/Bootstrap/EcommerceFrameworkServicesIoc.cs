using Ecommerce.Core.Auths;
using Ecommerce.Core.Framework;
using Ecommerce.Core.ShoppingCarts;
using Ecommerce.Framework.Auths;
using Ecommerce.Framework.Redis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Framework.Bootstrap
{
    public static class EcommerceFrameworkServicesIoc
    {
        public static IServiceCollection EcommerceFrameworkServicesDISetUp(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
               return ConnectionMultiplexer.Connect("localhost");
            });
            services.AddScoped<IJwtGenerator, JwtGeneator>();
            return services;
        }
    }
}
