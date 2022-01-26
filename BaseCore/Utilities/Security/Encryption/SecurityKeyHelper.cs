using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCore.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        /// <summary>
        /// Creates Symmetric security key by using the given security key.
        /// </summary>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
