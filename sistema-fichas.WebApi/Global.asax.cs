using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using sistema_fichas.WebApi.Controllers;
using sistema_fichas.Business;
using sistema_fichas.Repository;
using sistema_fichas.Repository.Core;
using System.Data.Entity;

namespace sistema_fichas.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Autofac Configuration
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            
            //Register Controllers
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();

            //Register Repository type
            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Repository.Core"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();


            //Register service type
            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Service"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Service.Core"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            //Register entity framework utils
            builder.RegisterType(typeof(FichasContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerApiRequest();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}