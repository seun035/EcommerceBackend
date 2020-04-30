using Ecommerce.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.UIApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleApplicationExceptionErrors(context, ex);
            }
        }

        private async Task HandleApplicationExceptionErrors(HttpContext context, Exception exception)
        {
            object error = null;

            switch (exception)
            {
                case AppException ex:
                    context.Response.StatusCode = ex.StatusCode;
                    error = ex.FriendlyMessage;
                    break;
                case Exception ex:
                    context.Response.StatusCode = 500;
                    error = "Internal server error";
                    break;
            }

            context.Response.ContentType = "application/json";

            if (error != null)
            {
                var result = JsonSerializer.Serialize(new { error });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
