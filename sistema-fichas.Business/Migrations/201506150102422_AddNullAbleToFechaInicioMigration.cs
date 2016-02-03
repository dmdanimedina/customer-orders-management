namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullAbleToFechaInicioMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PedidoDetalle", "FechaInicio", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PedidoDetalle", "FechaInicio", c => c.DateTime(nullable: false));
        }
    }
}
