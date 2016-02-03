namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJustInCase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patente", "Numero", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patente", "Numero", c => c.String());
        }
    }
}
