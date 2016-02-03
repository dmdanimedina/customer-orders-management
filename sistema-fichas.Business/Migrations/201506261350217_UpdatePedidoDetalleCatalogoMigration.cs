namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePedidoDetalleCatalogoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PedidoDetalle", "MonedaInst_ID", "dbo.Moneda");
            DropIndex("dbo.PedidoDetalle", new[] { "MonedaInst_ID" });
            DropPrimaryKey("dbo.PedidoDetalle");
            AddColumn("dbo.PedidoDetalle", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PedidoDetalle", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PedidoDetalle", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PedidoDetalle", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Catalogo", "ValorBase", c => c.String(nullable: false));
            AlterColumn("dbo.PedidoDetalle", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PedidoDetalle", "ID");
            DropColumn("dbo.PedidoDetalle", "MonedaInst_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PedidoDetalle", "MonedaInst_ID", c => c.Int());
            DropPrimaryKey("dbo.PedidoDetalle");
            AlterColumn("dbo.PedidoDetalle", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Catalogo", "ValorBase");
            DropColumn("dbo.PedidoDetalle", "UpdatedBy");
            DropColumn("dbo.PedidoDetalle", "UpdatedDate");
            DropColumn("dbo.PedidoDetalle", "CreatedBy");
            DropColumn("dbo.PedidoDetalle", "CreatedDate");
            AddPrimaryKey("dbo.PedidoDetalle", "ID");
            CreateIndex("dbo.PedidoDetalle", "MonedaInst_ID");
            AddForeignKey("dbo.PedidoDetalle", "MonedaInst_ID", "dbo.Moneda", "ID");
        }
    }
}
