namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeIntToDoubleMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Catalogo", "ValorBase");
            AddColumn("dbo.Catalogo", "ValorBase", c => c.Double(nullable: false));
            DropColumn("dbo.PedidoDetalle", "ValorInstalacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PedidoDetalle", "ValorInstalacion", c => c.Double());
            AlterColumn("dbo.Catalogo", "ValorBase", c => c.Int(nullable: false));
        }
    }
}
