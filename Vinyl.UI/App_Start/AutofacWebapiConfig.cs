using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Vinyl.Contracts;
using Vinyl.DAL.Concrete;
using Vinyl.DAL.Contract;
using Vinyl.DAL.Data;

namespace Vinyl.UI.App_Start
{
	public class AutofacWebapiConfig
	{

		public static IContainer Container;

		public static void Initialize(HttpConfiguration config)
		{
			Initialize(config, RegisterServices(new ContainerBuilder()));
		}


		public static void Initialize(HttpConfiguration config, IContainer container)
		{
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		private static IContainer RegisterServices(ContainerBuilder builder)
		{
			//Register your Web API controllers  
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<VinylContext>()
				 .As<DbContext>()
				 .InstancePerRequest();

			builder.RegisterGeneric(typeof(GenericRepository<>))
				 .As(typeof(IGenericRepository<>))
				 .InstancePerRequest();

			builder.RegisterType<UnitOfWork>()
				 .As<IUnitOfWork>()
				 .InstancePerRequest();

			//Set the dependency resolver to be Autofac.  
			Container = builder.Build();

			return Container;
		}

	}
}