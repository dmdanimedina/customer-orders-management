namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatenteModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patente", "Comentario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patente", "Comentario");
        }
    }
}
