using BaseCore.CrossCuttingConcerns.Caching;
using BaseCore.Utilities.Interceptors;
using BaseCore.Utilities.Tools;
using Castle.Core.Interceptor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BaseCore.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly ICacheManager _cacheManager;
        private readonly int _db;
        private readonly int? _duration;
        private readonly string _pattern;

        public CacheAspect(string pattern = "", int db = 0, int duration = 60)
        {
            _pattern = pattern;
            _duration = duration;
            _db = db;
            Priority = 3;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            var key = Key(invocation);
            //Course.GetAll(100,1,Null,Id,False)

            if (_cacheManager.AnyAsync(key).Result)
            {
                try
                {
                    var resultType = invocation.Method.ReturnType.GenericTypeArguments.FirstOrDefault();
                    var returnValue = _cacheManager.GetAsync(key).Result;

                    dynamic temp = JsonSerializer.Deserialize(returnValue, resultType!);
                    invocation.ReturnValue = Task.FromResult(temp);
                    return;
                }
                catch
                {
                    //
                }
            }

            invocation.Proceed();
            var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                invocation.ReturnValue = InterceptAsync((dynamic)invocation.ReturnValue, key);
            }
        }

        private static async Task InterceptAsync(Task task, string key)
        {
            await task.ConfigureAwait(false);
        }

        private async Task<T> InterceptAsync<T>(Task<T> task, string key)
        {
            var result = await task.ConfigureAwait(false);
            var data = JsonSerializer.Serialize(result);
            await _cacheManager.SetAsync(key, data, _duration, _db);
            return result;
        }

        private string Key(IInvocation invocation)
        {
            var methodName = string.IsNullOrEmpty(_pattern)
                ? $"{invocation.InvocationTarget.GetType().Name.Replace("Service", "")}.{invocation.Method.Name.Replace("Async", "")}"
                : _pattern;

            var arguments = invocation.Arguments.ToList();
            var parameters = "";
            for (var i = 0; i < arguments.Count; i++)
            {
                var arg = arguments[i];
                if (parameters != "") parameters += ",";
                if (arg?.GetType().IsClass ?? false)
                {
                    parameters += GetProperties(arg);
                }
                else
                {
                    parameters += arg?.ToString()?.Replace("/", "") ?? "Null";
                }
            }

            return $"{methodName}({parameters})";
        }

        private static string GetProperties(object arg)
        {
            //100,1,Null,Id,False
            try
            {
                return arg == null
                    ? "Null"
                    : arg.GetType().GetProperties().Select(x => x.GetValue(arg) ?? "Null")
                        .Aggregate("", (current, value) => current + (current == "" ? "" : ",") + $"{value}");
            }
            catch
            {
                return arg?.ToString()?.Replace("/", "") ?? "Null";
            }
        }
    }
}
