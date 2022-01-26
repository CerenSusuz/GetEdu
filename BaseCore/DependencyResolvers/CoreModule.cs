using BaseCore.CrossCuttingConcerns.Caching;
using BaseCore.CrossCuttingConcerns.Caching.Microsoft;
using BaseCore.Utilities.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    /// <summary>
    /// It involves IoC injections that are related with the Core layer.
    /// It loads general dependencies for the project.
    /// </summary>
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            // Cache
            services.AddMemoryCache();  // Microsoft's Cache
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>(); // PerformanceAspect
        }
    }
}
