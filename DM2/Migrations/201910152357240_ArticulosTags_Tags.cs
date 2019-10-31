namespace DM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticulosTags_Tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticulosTags",
                c => new
                    {
                        IdArtTag = c.Int(nullable: false, identity: true),
                        IdTag = c.Int(nullable: false),
                        IdArticle = c.Int(nullable: false),
                        Articles_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IdArtTag)
                .ForeignKey("dbo.Articles", t => t.Articles_Id)
                .ForeignKey("dbo.Tags", t => t.IdTag, cascadeDelete: true)
                .Index(t => t.IdTag)
                .Index(t => t.Articles_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        IdTag = c.Int(nullable: false, identity: true),
                        NombreTag = c.String(),
                    })
                .PrimaryKey(t => t.IdTag);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticulosTags", "IdTag", "dbo.Tags");
            DropForeignKey("dbo.ArticulosTags", "Articles_Id", "dbo.Articles");
            DropIndex("dbo.ArticulosTags", new[] { "Articles_Id" });
            DropIndex("dbo.ArticulosTags", new[] { "IdTag" });
            DropTable("dbo.Tags");
            DropTable("dbo.ArticulosTags");
        }
    }
}
