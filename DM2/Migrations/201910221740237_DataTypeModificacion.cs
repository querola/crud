namespace DM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTypeModificacion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "URL", c => c.String(maxLength: 100));
            AlterColumn("dbo.Articles", "Nombre", c => c.String(maxLength: 100));
            AlterColumn("dbo.Articles", "ImgURL", c => c.String(maxLength: 100));
            AlterColumn("dbo.Sections", "Nombre", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 70));
            AlterColumn("dbo.Users", "Nombre", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Apellido", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "ImagenURL", c => c.String(maxLength: 100));
            AlterColumn("dbo.Tags", "NombreTag", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "NombreTag", c => c.String());
            AlterColumn("dbo.Users", "ImagenURL", c => c.String());
            AlterColumn("dbo.Users", "Apellido", c => c.String());
            AlterColumn("dbo.Users", "Nombre", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Sections", "Nombre", c => c.String());
            AlterColumn("dbo.Articles", "ImgURL", c => c.String());
            AlterColumn("dbo.Articles", "Nombre", c => c.String());
            AlterColumn("dbo.Articles", "URL", c => c.String());
        }
    }
}
