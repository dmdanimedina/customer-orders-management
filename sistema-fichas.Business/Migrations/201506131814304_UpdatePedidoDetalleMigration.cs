namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePedidoDetalleMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PedidoDetalle", "FechaTermino", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PedidoDetalle", "FechaTermino", c => c.DateTime(nullable: false));
        }
    }
}
