using BusinessLayer.Repositories.Abstract;
using BusinessLayer.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Repositories.Concrete;
using DataAccessLayer.Repositories.Abstract;

namespace API.Installers.Services
{
    public class InterfaceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {

            services.AddSingleton(typeof(IEntityRepository<>), typeof(EFEntityRepositoryBase<>));
            services.AddSingleton(typeof(IServiceRepository<,>), typeof(ServiceRepository<,>));
            services.AddSingleton(typeof(IPairingServiceRepository<,>), typeof(PairingServiceRepository<,>));
            
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            
            services.AddSingleton<IAuthService, AuthManager>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IOperationClaimService, OperationClaimManager>();
            services.AddSingleton<ICategoryService , CategoryManager>();


            services.AddSingleton<IUserDAL, EFUserDAL>();
        }
    }
}