using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace TEK_Careers.API.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TEK-Careers.Domain.Repository"),
                               Assembly.Load("TEK-Careers.Domain.RepositoryPattern"))
                           .Where(t => t.Name.EndsWith("Repository"))
                           .AsImplementedInterfaces()
                           .InstancePerLifetimeScope();
        }
    }
}