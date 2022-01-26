using System;
using System.Collections.Generic;
using System.Text;
using BaseCore.Extensions;
using Microsoft.AspNetCore.Builder;

namespace BaseCore.Extensions
{ 
    /// <summary>
    /// Custome middleware for handling exceptions.
    /// </summary>
public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// Handles exceptions by using ExceptionMiddleware.
    /// </summary>
    /// <param name="app"></param>
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
}
