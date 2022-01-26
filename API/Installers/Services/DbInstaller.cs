using API.Installers;
using DataAccessLayer.Contexts.EF;
using Microsoft.EntityFrameworkCore;

namespace Api.Installers.Services
{
    public class DbInstaller : IServiceInstaller, IConfigureInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddDbContext<GetEduContext>(
                o => { o.UseSqlServer(@"Server=ETR-LT167;Database=GetEduDb;Trusted_Connection=true;"); }
                , ServiceLifetime.Transient
            );
            
        }

        public void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var context = app.ApplicationServices.GetService<GetEduContext>();
            context?.Database?.Migrate();
        }
    }
}