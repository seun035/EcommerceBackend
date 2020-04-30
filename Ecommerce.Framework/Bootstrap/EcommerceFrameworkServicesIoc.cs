using Ecommerce.Core.ShoppingCarts;
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
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
               return ConnectionMultiplexer.Connect("localhost");
            });
            return services;
        }
    }
}
