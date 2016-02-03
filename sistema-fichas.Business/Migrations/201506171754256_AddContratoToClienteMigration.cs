namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContratoToClienteMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Contrato", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Contrato");
        }
    }
}
