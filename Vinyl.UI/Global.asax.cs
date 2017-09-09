using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Vinyl.UI.Modules;
using Vinyl.UI.ViewModels;
using Vinyl.UI.Infra;
using System;
using Vinyl.UI.Mappers;

namespace Vinyl.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ModelBinder
            ModelBinders.Binders.Add(typeof(ParametrosPaginacao), new ParametrosPaginacaoModelBinder());
            //ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
            //ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());

            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterModule(new RepositoryModule());

            // In the future could be implemented a DDD. So a new layer with a ServiceModule is required
            //builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Configuring AutoMapper to register the mapping profiles during application startup.
            AutoMapperConfig.RegisterMappings();
        }
    }
}
