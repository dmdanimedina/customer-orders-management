using Autofac.Integration.Mvc;
using Autofac;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_fichas.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("sistema-fichas.Repository.Core"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }

}