using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ecommerce.Data.Bootstrap;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.UIApiServices.Bootstrap;
using Ecommerce.DomainServices.Bootstrap;
using Ecommerce.Framework.Bootstrap;
using Ecommerce.UIApi.Middlewares;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommerce.Core.Users;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.UIApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EcommerceDbContext>((option) => { option.UseSqlite(Configuration.GetConnectionString("DefaultConnection")); });
            services.EcommerceDataDISetUp();
            services.EcommerceDomainServiceDISetUp();
            services.EcommerceUIApiServicesDISetUp();
            services.EcommerceFrameworkServicesDISetUp();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors(option => option.AddPolicy("CorsPolicy", c => c.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200")
                       .AllowCredentials()));
            services.AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Key")),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce Api V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
