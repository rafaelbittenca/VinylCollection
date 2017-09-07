namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AboutLink = c.String(maxLength: 200, unicode: false),
                        Picture = c.Binary(),
                        LastName = c.String(nullable: false, maxLength: 200, unicode: false),
                        FirstMidName = c.String(nullable: false, maxLength: 200, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 150, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200, unicode: false),
                        Year = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Cover = c.Binary(),
                        ArtistId = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 150, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artist", t => t.ArtistId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Password = c.String(nullable: false, maxLength: 150, unicode: false),
                        Avatar = c.Binary(),
                        LastName = c.String(maxLength: 200, unicode: false),
                        FirstMidName = c.String(maxLength: 200, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 150, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Record", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Record", new[] { "ArtistId" });
            DropTable("dbo.User");
            DropTable("dbo.Record");
            DropTable("dbo.Artist");
        }
    }
}
