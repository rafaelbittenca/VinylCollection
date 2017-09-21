namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropNamePersonClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artist", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AddColumn("dbo.User", "Name", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Name");
            DropColumn("dbo.Artist", "Name");
        }
    }
}
