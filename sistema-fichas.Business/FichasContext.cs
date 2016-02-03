using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace sistema_fichas.Business
{
    public class FichasContext : DbContext
    {
        public FichasContext()
            : base("Name=FichasContext")
        {
        
        }

        // SimpleMembership
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OAuthMembership> OAuthMembership { get; set; }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Industria> Industrias { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<TipoCliente> TiposCliente { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<EstadoDetalle> EstadosDetalle { get; set; }
        public DbSet<Adjunto> Adjuntos { get; set; }
        public DbSet<PedidoDetalle> PedidosDetalle { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Patente> Patentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Membership>()
              .HasMany<Role>(r => r.Roles)
              .WithMany(u => u.Members)
              .Map(m =>
              {
                  m.ToTable("webpages_UsersInRoles");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("RoleId");
              });
            modelBuilder.Entity<Cliente>()
                .HasMany(t => t.Direcciones)
                .WithMany(t => t.Clientes)
                .Map(m =>
                {
                    m.ToTable("ClienteDireccion");
                    m.MapLeftKey("Cliente_ID");
                    m.MapRightKey("Direccion_ID");
                });
            modelBuilder.Entity<Catalogo>()
                .HasMany(t => t.Herramientas)
                .WithMany(t => t.Catalogos)
                .Map(m =>
                {
                    m.ToTable("CatalogoHerramienta");
                    m.MapLeftKey("Catalogo_ID");
                    m.MapRightKey("Herramienta_ID");
                });

        }


        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    String identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;
                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;

                }
            }
            return base.SaveChanges();
        }

    }
}
