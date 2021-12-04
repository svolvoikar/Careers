using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace TEK_Careers.API.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TEK-Careers.Application.Services"),
                   Assembly.Load("TEK-Careers.Application.ServicePattern"))
               .Where(t => t.Name.EndsWith("Service"))
               .PropertiesAutowired()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        }
    }
}