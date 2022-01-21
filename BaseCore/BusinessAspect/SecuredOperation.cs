using BaseCore.Utilities.Interceptors;
using BaseCore.Utilities.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BaseCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCore.Constants;
using Castle.DynamicProxy;

namespace BaseCore.BusinessAspect
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var roleClaim in _roles)
            {
                if (roleClaims.Contains(roleClaim))
                {
                    return;
                }
                throw new Exception(Messages.AuthorizationDenied);
            }
        }



    }
}
