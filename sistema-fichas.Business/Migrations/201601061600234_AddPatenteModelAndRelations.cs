namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatenteModelAndRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patente",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Numero = c.String(),
                        estado = c.Int(),
                        Cliente_ID = c.Long(),
                        PedidoDetalle_ID = c.Long(),
                        Pedido_ID = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ID)
                .ForeignKey("dbo.Pedido", t => t.Pedido_ID)
                .ForeignKey("dbo.PedidoDetalle", t => t.PedidoDetalle_ID)
                .Index(t => t.Cliente_ID)
                .Index(t => t.PedidoDetalle_ID)
                .Index(t => t.Pedido_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patente", "PedidoDetalle_ID", "dbo.PedidoDetalle");
            DropForeignKey("dbo.Patente", "Pedido_ID", "dbo.Pedido");
            DropForeignKey("dbo.Patente", "Cliente_ID", "dbo.Cliente");
            DropIndex("dbo.Patente", new[] { "Pedido_ID" });
            DropIndex("dbo.Patente", new[] { "PedidoDetalle_ID" });
            DropIndex("dbo.Patente", new[] { "Cliente_ID" });
            DropTable("dbo.Patente");
        }
    }
}
