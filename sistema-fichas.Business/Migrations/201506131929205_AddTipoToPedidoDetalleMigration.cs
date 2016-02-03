namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoToPedidoDetalleMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PedidoDetalle", "Tipo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoDetalle", "Tipo");
        }
    }
}
