namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoToCatalogoMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogo", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catalogo", "Estado");
        }
    }
}
