using TEK_Careers.Framework.GenericRepository;
using Autofac;
using TEK_Careers.Domain.Model;
using System.Data.Entity;

namespace TEK_Careers.API.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(CareersEntities)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
        }
    }
}