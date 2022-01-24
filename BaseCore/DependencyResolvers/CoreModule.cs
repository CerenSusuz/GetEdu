﻿using BaseCore.CrossCuttingConcerns.Caching;
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
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}