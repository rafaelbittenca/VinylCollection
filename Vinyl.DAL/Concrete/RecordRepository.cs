using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Vinyl.DAL.Contract;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
	public class RecordRepository : GenericRepository<Record>, IRecordRepository
	{
		public RecordRepository(DbContext context)
		    : base(context)
		{

		}

		public Record GetById(int id)
		{
			return _entities.Set<Record>()
				          .Include("Artist")
					    .Where(r => r.ID == id)
					    .FirstOrDefault();
		}

		public async Task<Record> GetByIdAsync(int id)
		{
			return await _entities.Set<Record>()
					          .Include("Artist")
					          .Where(r => r.ID == id)
					          .FirstOrDefaultAsync();
		}

		public IEnumerable<Record> GetRecordsByArtist(int artistid)
		{
			return _entities.Set<Record>()
				          .Include("Artist")
					    .Where(r => r.ArtistId == artistid);
		}

		public async Task<IEnumerable<Record>> GetRecordsByArtistAsync(int artistid)
		{
			return await _entities.Set<Record>()
					          .Include("Artist")
					          .Where(r => r.ArtistId == artistid)
						    .ToListAsync();
		}
	}
}
