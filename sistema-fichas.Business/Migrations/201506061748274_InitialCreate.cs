namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adjunto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 245),
                        FechaHora = c.DateTime(nullable: false),
                        Ruta = c.String(maxLength: 245),
                        Version = c.Int(),
                        Estado = c.Int(nullable: false),
                        Pedido_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pedido", t => t.Pedido_ID, cascadeDelete: true)
                .Index(t => t.Pedido_ID);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(),
                        FechaTermino = c.DateTime(),
                        Facturado = c.Boolean(nullable: false),
                        Cliente_ID = c.Long(nullable: false),
                        UserProfile_ID = c.Int(nullable: false),
                        EstadoPedido_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ID, cascadeDelete: true)
                .ForeignKey("dbo.EstadoPedido", t => t.EstadoPedido_ID)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_ID, cascadeDelete: true)
                .Index(t => t.Cliente_ID)
                .Index(t => t.UserProfile_ID)
                .Index(t => t.EstadoPedido_ID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Rut = c.String(nullable: false, maxLength: 245),
                        NombreFantasia = c.String(nullable: false, maxLength: 245),
                        RazonSocial = c.String(nullable: false, maxLength: 245),
                        Giro = c.String(nullable: false, maxLength: 245),
                        Telefono = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Industria_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                        TipoCliente_ID = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Industria", t => t.Industria_ID, cascadeDelete: true)
                .ForeignKey("dbo.TipoCliente", t => t.TipoCliente_ID)
                .Index(t => t.Industria_ID)
                .Index(t => t.TipoCliente_ID);
            
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 245),
                        Cargo = c.String(maxLength: 245),
                        Email = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(nullable: false),
                        Tipo = c.Int(),
                        Estado = c.Byte(nullable: false),
                        Cliente_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ID)
                .Index(t => t.Cliente_ID);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Observacion = c.String(maxLength: 245),
                        Calle = c.String(nullable: false, maxLength: 245),
                        Numero = c.String(nullable: false, maxLength: 245),
                        Departamento = c.String(maxLength: 245),
                        Ciudad = c.String(maxLength: 245),
                        Comuna = c.String(maxLength: 245),
                        Latitud = c.String(maxLength: 245),
                        Longitud = c.String(maxLength: 245),
                        Tipo = c.Int(),
                        Estado = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Industria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 245),
                        Estado = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipoCliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Sigla = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EstadoPedido",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 245),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PedidoDetalle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(),
                        Valor = c.Double(),
                        ValorInstalacion = c.Double(),
                        TipoCobro = c.Int(nullable: false),
                        Comentario = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaTermino = c.DateTime(nullable: false),
                        Pedido_ID = c.Int(nullable: false),
                        EstadoDetalle_ID = c.Int(nullable: false),
                        Catalogo_ID = c.Int(),
                        Herramienta_ID = c.Int(),
                        Modalidad_ID = c.Int(),
                        Moneda_ID = c.Int(nullable: false),
                        MonedaInst_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Herramienta", t => t.Herramienta_ID)
                .ForeignKey("dbo.Catalogo", t => t.Catalogo_ID)
                .ForeignKey("dbo.EstadoDetalle", t => t.EstadoDetalle_ID, cascadeDelete: true)
                .ForeignKey("dbo.Modalidad", t => t.Modalidad_ID)
                .ForeignKey("dbo.Moneda", t => t.Moneda_ID, cascadeDelete: true)
                .ForeignKey("dbo.Moneda", t => t.MonedaInst_ID)
                .ForeignKey("dbo.Pedido", t => t.Pedido_ID, cascadeDelete: true)
                .Index(t => t.Pedido_ID)
                .Index(t => t.EstadoDetalle_ID)
                .Index(t => t.Catalogo_ID)
                .Index(t => t.Herramienta_ID)
                .Index(t => t.Modalidad_ID)
                .Index(t => t.Moneda_ID)
                .Index(t => t.MonedaInst_ID);
            
            CreateTable(
                "dbo.Catalogo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Herramienta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EstadoDetalle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 245),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Modalidad",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 245),
                        Alias = c.String(maxLength: 245),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ConfirmationToken = c.String(maxLength: 128),
                        IsConfirmed = c.Boolean(),
                        LastPasswordFailureDate = c.DateTime(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordChangedDate = c.DateTime(),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        PasswordVerificationToken = c.String(maxLength: 128),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        Provider = c.String(nullable: false, maxLength: 30),
                        ProviderUserId = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider, t.ProviderUserId })
                .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.ClienteDireccion",
                c => new
                    {
                        Cliente_ID = c.Long(nullable: false),
                        Direccion_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cliente_ID, t.Direccion_ID })
                .ForeignKey("dbo.Cliente", t => t.Cliente_ID, cascadeDelete: true)
                .ForeignKey("dbo.Direccion", t => t.Direccion_ID, cascadeDelete: true)
                .Index(t => t.Cliente_ID)
                .Index(t => t.Direccion_ID);
            
            CreateTable(
                "dbo.CatalogoHerramienta",
                c => new
                    {
                        Catalogo_ID = c.Int(nullable: false),
                        Herramienta_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Catalogo_ID, t.Herramienta_ID })
                .ForeignKey("dbo.Catalogo", t => t.Catalogo_ID, cascadeDelete: true)
                .ForeignKey("dbo.Herramienta", t => t.Herramienta_ID, cascadeDelete: true)
                .Index(t => t.Catalogo_ID)
                .Index(t => t.Herramienta_ID);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.webpages_OAuthMembership", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.Pedido", "UserProfile_ID", "dbo.UserProfile");
            DropForeignKey("dbo.PedidoDetalle", "Pedido_ID", "dbo.Pedido");
            DropForeignKey("dbo.PedidoDetalle", "MonedaInst_ID", "dbo.Moneda");
            DropForeignKey("dbo.PedidoDetalle", "Moneda_ID", "dbo.Moneda");
            DropForeignKey("dbo.PedidoDetalle", "Modalidad_ID", "dbo.Modalidad");
            DropForeignKey("dbo.PedidoDetalle", "EstadoDetalle_ID", "dbo.EstadoDetalle");
            DropForeignKey("dbo.PedidoDetalle", "Catalogo_ID", "dbo.Catalogo");
            DropForeignKey("dbo.CatalogoHerramienta", "Herramienta_ID", "dbo.Herramienta");
            DropForeignKey("dbo.CatalogoHerramienta", "Catalogo_ID", "dbo.Catalogo");
            DropForeignKey("dbo.PedidoDetalle", "Herramienta_ID", "dbo.Herramienta");
            DropForeignKey("dbo.Pedido", "EstadoPedido_ID", "dbo.EstadoPedido");
            DropForeignKey("dbo.Cliente", "TipoCliente_ID", "dbo.TipoCliente");
            DropForeignKey("dbo.Pedido", "Cliente_ID", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "Industria_ID", "dbo.Industria");
            DropForeignKey("dbo.ClienteDireccion", "Direccion_ID", "dbo.Direccion");
            DropForeignKey("dbo.ClienteDireccion", "Cliente_ID", "dbo.Cliente");
            DropForeignKey("dbo.Contacto", "Cliente_ID", "dbo.Cliente");
            DropForeignKey("dbo.Adjunto", "Pedido_ID", "dbo.Pedido");
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.CatalogoHerramienta", new[] { "Herramienta_ID" });
            DropIndex("dbo.CatalogoHerramienta", new[] { "Catalogo_ID" });
            DropIndex("dbo.ClienteDireccion", new[] { "Direccion_ID" });
            DropIndex("dbo.ClienteDireccion", new[] { "Cliente_ID" });
            DropIndex("dbo.webpages_OAuthMembership", new[] { "UserId" });
            DropIndex("dbo.PedidoDetalle", new[] { "MonedaInst_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "Moneda_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "Modalidad_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "Herramienta_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "Catalogo_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "EstadoDetalle_ID" });
            DropIndex("dbo.PedidoDetalle", new[] { "Pedido_ID" });
            DropIndex("dbo.Contacto", new[] { "Cliente_ID" });
            DropIndex("dbo.Cliente", new[] { "TipoCliente_ID" });
            DropIndex("dbo.Cliente", new[] { "Industria_ID" });
            DropIndex("dbo.Pedido", new[] { "EstadoPedido_ID" });
            DropIndex("dbo.Pedido", new[] { "UserProfile_ID" });
            DropIndex("dbo.Pedido", new[] { "Cliente_ID" });
            DropIndex("dbo.Adjunto", new[] { "Pedido_ID" });
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.CatalogoHerramienta");
            DropTable("dbo.ClienteDireccion");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.webpages_OAuthMembership");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Moneda");
            DropTable("dbo.Modalidad");
            DropTable("dbo.EstadoDetalle");
            DropTable("dbo.Herramienta");
            DropTable("dbo.Catalogo");
            DropTable("dbo.PedidoDetalle");
            DropTable("dbo.EstadoPedido");
            DropTable("dbo.TipoCliente");
            DropTable("dbo.Industria");
            DropTable("dbo.Direccion");
            DropTable("dbo.Contacto");
            DropTable("dbo.Cliente");
            DropTable("dbo.Pedido");
            DropTable("dbo.Adjunto");
        }
    }
}
