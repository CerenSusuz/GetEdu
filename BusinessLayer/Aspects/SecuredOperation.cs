﻿using BaseCore.Extensions;
using BaseCore.Utilities.Interceptors;
using BaseCore.Utilities.Tools;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security;

namespace BusinessLayer.Aspects
{
    /// <summary>
    /// Handles operation-based authorizations.
    /// It compares the user's role claims with the role permissions assigned to the operation.
    /// </summary>
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Requires stringfy roles or a role.
        /// </summary>
        /// <param name="roles"></param>
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        /// <summary>
        /// Gets the roles that are assigned to related operation. If the list of role claims of the current user is contains one of the defined roles for the related operation, it will return null, else throws exception with an authorization message. 
        /// </summary>
        /// <param name="invocation">Related operations it self.</param>
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new SecurityException("AuthorizationDenied");
        }
    }
}
