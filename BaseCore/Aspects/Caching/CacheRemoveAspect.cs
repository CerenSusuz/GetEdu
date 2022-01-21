using BaseCore.CrossCuttingConcerns.Caching;
using BaseCore.Utilities.Interceptors;
using BaseCore.Utilities.Tools;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Aspects.Caching
{
    internal class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        private readonly int _db;

        public CacheRemoveAspect(string pattern = "", int db = 0)
        {
            _pattern = pattern;
            _db = db;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            var key = _pattern == "" ? $"{invocation.InvocationTarget.GetType().Name.Replace("Service", "")}" : _pattern;
            if (invocation.Method.ReflectedType == null) return;
            _cacheManager.RemoveByPatternAsync(_pattern);
        }
    }
}
