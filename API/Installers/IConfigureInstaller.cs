
namespace API.Installers
{
    public interface IConfigureInstaller
    {
        /// <summary>
        /// Install Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}