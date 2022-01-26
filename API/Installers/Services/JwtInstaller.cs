using System.Text;
using BaseCore.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Installers.Services
{
    public class JwtInstaller : IServiceInstaller 
    {
        public IConfiguration Configuration { get; }
        public void InstallService(IServiceCollection services)
        {
            var tokenOptions = new TokenOptions
            {
                Audience = "ceren@ceren.com",
                Issuer = "ceren@ceren.com",
                SecurityKey = "F2peYX7865Yk8wztCxg8jzZGF5yEx4vu4TK4mN8DLtsVpnGa3V5jabYjFhGf",
                AccessTokenExpiration = 10
            };
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
        }
    }
}