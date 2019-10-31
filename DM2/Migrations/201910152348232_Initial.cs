namespace DM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Nombre = c.String(),
                        Body = c.String(),
                        ImgURL = c.String(),
                        IdUser = c.Int(nullable: false),
                        IdSection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
