namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndexPropNameArtistClass : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Artist", "Name", unique: true, name: "UQ_Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Artist", "UQ_Name");
        }
    }
}
