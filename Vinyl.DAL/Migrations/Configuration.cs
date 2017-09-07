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

            List<Artist> artists = new List<Artist>()
            {
                new Artist() { FirstMidName="Eric", LastName="Clapton", BirthDate = new DateTime(1945, 03, 30) },
                new Artist() { FirstMidName="Ben", LastName="Harper", BirthDate = new DateTime(1969, 10, 28) },
                new Artist() { FirstMidName="Bob", LastName="Dylan", BirthDate = new DateTime(1941, 05, 24) },
                new Artist() { FirstMidName="David", LastName="Gilmour", BirthDate = new DateTime(1946, 03, 06) },
                new Artist() { FirstMidName="Bob", LastName="Marley", BirthDate = new DateTime(1945, 02, 06) },
                new Artist() { FirstMidName="John", LastName="Mayer", BirthDate = new DateTime(1977, 10, 16) },
                new Artist() { FirstMidName="John", LastName="Lennon", BirthDate = new DateTime(1975, 10, 09) },
                new Artist() { FirstMidName="Roger", LastName="Waters", BirthDate = new DateTime(1943, 09, 06) },
                new Artist() { FirstMidName="Bruce", LastName="Springsteen", BirthDate = new DateTime(1949, 09, 23) },
                new Artist() { FirstMidName="B. B.", LastName="King", BirthDate = new DateTime(1925, 09, 16) },

                new Artist() { FirstMidName="Tim", LastName="Maia", BirthDate = new DateTime(1942, 09, 28) },

                new Artist() { FirstMidName="George", LastName="Harrison", BirthDate = new DateTime(1943, 02, 25) },

                new Artist() { FirstMidName="Pink", LastName="Floyd", BirthDate = new DateTime(1965, 01, 01) },
                new Artist() { FirstMidName="Pearl", LastName=" Jam", BirthDate = new DateTime(1990, 01, 01) },
            };

            artists.ForEach(a => context.Artists.Add(a));

            context.SaveChanges();

        }
    }
}
