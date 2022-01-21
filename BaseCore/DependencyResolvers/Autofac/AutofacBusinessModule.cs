using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;
using BaseCore.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace BaseCore.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()

                }).SingleInstance();
        }
    }
}