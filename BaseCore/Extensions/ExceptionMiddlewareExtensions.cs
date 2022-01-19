using System;
using System.Collections.Generic;
using System.Text;
using BaseCore.Extensions;
using Microsoft.AspNetCore.Builder;

namespace BaseCore.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
