namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUniqueIndexFirstLastNameOnTableArtist : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Artist", "UQ_First_Last_Name");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Artist", new[] { "FirstMidName", "LastName" }, unique: true, name: "UQ_First_Last_Name");
        }
    }
}
