using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vinyl.DAL.Contract;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(DbContext context)
            :base(context)
        {

        }
        public Artist GetById(long? id)
        {
            return Find(x => x.ID == id).FirstOrDefault();
        }
    }
}
