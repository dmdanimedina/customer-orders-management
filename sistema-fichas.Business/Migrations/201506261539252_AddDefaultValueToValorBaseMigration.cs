namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueToValorBaseMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Catalogo", "ValorBase", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Catalogo", "ValorBase", c => c.String(nullable: false));
        }

        
    }
}
