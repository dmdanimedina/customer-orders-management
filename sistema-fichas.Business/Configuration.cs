namespace sistema_fichas.Migrations
{
   /* using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    using sistema_fichas.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<sistema_fichas.DAL.SistemaFichasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(sistema_fichas.DAL.SistemaFichasContext context)
        {
            //Some seed registers
            SeedMembership();
            SeedIndustria(context);
            SeedTipoCliente(context);
        
        }

        private void SeedIndustria(sistema_fichas.DAL.SistemaFichasContext context)
        {
            var industrias = new List<Industria>
            {
                new Industria { Nombre = "Minería",   Estado = 1 },
                new Industria { Nombre = "Construcción",   Estado = 1 },
                new Industria { Nombre = "Forestal",   Estado = 1 },
                new Industria { Nombre = "Retail",   Estado = 1 },
                new Industria { Nombre = "Entrepreneurship",   Estado = 1 },
                
            };
            industrias.ForEach(s => context.Industrias.AddOrUpdate(p => p.Nombre, s));
            context.SaveChanges();
        }

        private void SeedTipoCliente(sistema_fichas.DAL.SistemaFichasContext context)
        {
            var tiposCliente = new List<TipoCliente>
            {
                new TipoCliente { Nombre = "Cliente",   Sigla = "Cliente" },
                new TipoCliente { Nombre = "Externo/Relacionado",   Sigla = "Ext/Rel" },                
                
            };
            tiposCliente.ForEach(s => context.TiposCliente.AddOrUpdate(p => p.Nombre, s));
            context.SaveChanges();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("SistemaFichasContext",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider) Roles.Provider;
            var membership = (SimpleMembershipProvider) System.Web.Security.Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("administrator", false) == null)
            {
                membership.CreateUserAndAccount("administrator", "secreto123");
            }
            if (!roles.GetRolesForUser("administrator").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "administrator" }, new[] { "Admin" });
            }
        }
    }
    * */
}
