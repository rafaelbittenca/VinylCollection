namespace Vinyl.DAL.Migrations
{
	using Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Vinyl.DAL.Data.VinylContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(Vinyl.DAL.Data.VinylContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			//	List<Artist> artists = new List<Artist>()
			//{
			//    new Artist() { Name="Eric Clapton", AboutLink="http://www.ericclapton.com/", BirthDate = new DateTime(1945, 03, 30) },
			//    new Artist() { Name="Ben Harper", AboutLink="http://www.benharper.com/", BirthDate = new DateTime(1969, 10, 28) },
			//    new Artist() { Name="Bob Dylan", AboutLink="https://www.bobdylan.com/", BirthDate = new DateTime(1941, 05, 24) },
			//    new Artist() { Name="David Gilmour", AboutLink="http://www.davidgilmour.com/", BirthDate = new DateTime(1946, 03, 06) },
			//    new Artist() { Name="B. B. King", AboutLink="http://www.bbking.com/", BirthDate = new DateTime(1925, 09, 16) },
			//    new Artist() { Name="Bob Marley", AboutLink="http://www.bobmarley.com/", BirthDate = new DateTime(1945, 02, 06) },
			//    new Artist() { Name="John Mayer", AboutLink="http://johnmayer.com/", BirthDate = new DateTime(1977, 10, 16) },
			//    new Artist() { Name="John Lennon", AboutLink="http://www.johnlennon.com/", BirthDate = new DateTime(1975, 10, 09) },
			//    new Artist() { Name="Roger Waters", AboutLink="https://rogerwaters.com/", BirthDate = new DateTime(1943, 09, 06) },
			//    new Artist() { Name="Bruce Springsteen", AboutLink="http://brucespringsteen.net/", BirthDate = new DateTime(1949, 09, 23) },
			//    new Artist() { Name="Tim Maia", AboutLink="https://en.wikipedia.org/wiki/Tim_Maia", BirthDate = new DateTime(1942, 09, 28) },
			//    new Artist() { Name="George Harrison", AboutLink="http://www.georgeharrison.com/", BirthDate = new DateTime(1943, 02, 25) },
			//    new Artist() { Name="Pink Floyd", AboutLink="http://www.pinkfloyd.com/", BirthDate = new DateTime(1965, 01, 01) },
			//    new Artist() { Name="Pearl Jam", AboutLink="https://pearljam.com/", BirthDate = new DateTime(1990, 01, 01) },
			//};

			//	artists.ForEach(a => context.Artists.Add(a));

			//	context.SaveChanges();

		}
	}
}
