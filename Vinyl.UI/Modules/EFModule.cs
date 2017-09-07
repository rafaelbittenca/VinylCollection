using Autofac;
using System.Data.Entity;
using Vinyl.DAL.Concrete;
using Vinyl.DAL.Contract;
using Vinyl.DAL.Data;

namespace Vinyl.UI.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(VinylContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}