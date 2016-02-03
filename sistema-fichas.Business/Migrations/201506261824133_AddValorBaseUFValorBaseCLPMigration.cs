namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValorBaseUFValorBaseCLPMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogo", "ValorBaseUF", c => c.Double(nullable: false));
            AddColumn("dbo.Catalogo", "ValorBaseCLP", c => c.Double(nullable: false));
            DropColumn("dbo.Catalogo", "ValorBase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Catalogo", "ValorBase", c => c.Double(nullable: false));
            DropColumn("dbo.Catalogo", "ValorBaseCLP");
            DropColumn("dbo.Catalogo", "ValorBaseUF");
        }
    }
}
