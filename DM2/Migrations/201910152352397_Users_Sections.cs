namespace DM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users_Sections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        IdSection = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdSection);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        ImagenURL = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateIndex("dbo.Articles", "IdUser");
            CreateIndex("dbo.Articles", "IdSection");
            AddForeignKey("dbo.Articles", "IdSection", "dbo.Sections", "IdSection", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Articles", "IdSection", "dbo.Sections");
            DropIndex("dbo.Articles", new[] { "IdSection" });
            DropIndex("dbo.Articles", new[] { "IdUser" });
            DropTable("dbo.Users");
            DropTable("dbo.Sections");
        }
    }
}
