namespace Vinyl.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePropNameArtistClass : DbMigration
    {
        public override void Up()
        {
		Sql("UPDATE Artist SET Name = FirstMidName + ' ' + LastName");
        }
        
        public override void Down()
        {
		Sql("UPDATE Artist SET Name = null");
        }
    }
}
