﻿using Ecommerce.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
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
                    error = new { ex.StatusCode, Message = ex.FriendlyMessage };
                    break;
                case Exception ex:
                    context.Response.StatusCode = 500;
                    error = new { StatusCode = 500, ex.Message, ex.StackTrace };
                    break;
            }

            context.Response.ContentType = "application/json";

            if (error != null)
            {
                var namingPolicy = new JsonSerializerOptions();
                namingPolicy.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                var result = JsonSerializer.Serialize(error, namingPolicy);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
