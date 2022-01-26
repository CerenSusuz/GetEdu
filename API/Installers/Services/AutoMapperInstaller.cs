using API.Installers;
using AutoMapper;
using EntityLayer.Entities.AutoMapper;

namespace Api.Installers.Services
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            // Automapper injection
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
                
            }).CreateMapper());
            
            
            
        }
    }
}