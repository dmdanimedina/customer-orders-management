namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToAllClases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adjunto", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Pedido", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Cliente", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Contacto", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Direccion", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Industria", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.TipoCliente", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.EstadoPedido", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.PedidoDetalle", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Catalogo", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Herramienta", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.EstadoDetalle", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Modalidad", "Status", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Moneda", "Status", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moneda", "Status");
            DropColumn("dbo.Modalidad", "Status");
            DropColumn("dbo.EstadoDetalle", "Status");
            DropColumn("dbo.Herramienta", "Status");
            DropColumn("dbo.Catalogo", "Status");
            DropColumn("dbo.PedidoDetalle", "Status");
            DropColumn("dbo.EstadoPedido", "Status");
            DropColumn("dbo.TipoCliente", "Status");
            DropColumn("dbo.Industria", "Status");
            DropColumn("dbo.Direccion", "Status");
            DropColumn("dbo.Contacto", "Status");
            DropColumn("dbo.Cliente", "Status");
            DropColumn("dbo.Pedido", "Status");
            DropColumn("dbo.Adjunto", "Status");
        }
    }
}
