using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Vinyl.DAL.Contract;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
	public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
	{
		public ArtistRepository(DbContext context)
		    : base(context)
		{

		}
		public Artist GetById(long? id)
		{
			return _entities.Set<Artist>()
				          .Include("Records")
					    .Where(a => a.ID == id)
					    .FirstOrDefault();
		}

		public async Task<Artist> GetByIdAsync(long? id)
		{
			return await _entities.Set<Artist>()
						    .Include("Records")
						    .Where(a => a.ID == id)
						    .FirstOrDefaultAsync();
		}

		public IEnumerable<Artist> GetAllWithRecords()    
		{
			return _entities.Set<Artist>()
					    .Include("Records");
		}

		public async Task<IEnumerable<Artist>> GetAllWithRecordsAsync()
		{
			return await _entities.Set<Artist>()
					          .Include("Records")
						    .ToListAsync();
		}
	}
}
