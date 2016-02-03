namespace sistema_fichas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cliente", "User_ID");
            AddForeignKey("dbo.Cliente", "User_ID", "dbo.UserProfile", "UserId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "User_ID", "dbo.UserProfile");
            DropIndex("dbo.Cliente", new[] { "User_ID" });
        }
    }
}
