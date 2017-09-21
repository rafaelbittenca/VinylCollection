namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePropFirstAndLastNameFromPersonClass : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Artist", "UQ_First_Last_Name");
            DropColumn("dbo.Artist", "LastName");
            DropColumn("dbo.Artist", "FirstMidName");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstMidName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FirstMidName", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.User", "LastName", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Artist", "FirstMidName", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AddColumn("dbo.Artist", "LastName", c => c.String(nullable: false, maxLength: 200, unicode: false));
            CreateIndex("dbo.Artist", new[] { "FirstMidName", "LastName" }, unique: true, name: "UQ_First_Last_Name");
        }
    }
}
