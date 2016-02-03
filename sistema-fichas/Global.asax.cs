using sistema_fichas.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac;
using sistema_fichas.Modules;

namespace sistema_fichas
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString()); 
            info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"; 
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
            ModelBinders.Binders.Add(typeof(decimal), new sistema_fichas.Filters.ModelBinder.DecimalModelBinder());

            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();
            
            //Register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}