using System.Collections.Generic;
using System.Threading.Tasks;
using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
	public interface IArtistRepository : IGenericRepository<Artist>
	{
		Artist GetById(long? id);
		IEnumerable<Artist> GetAllWithRecords();

		Task<Artist> GetByIdAsync(long? id);
		Task<IEnumerable<Artist>> GetAllWithRecordsAsync();
	}
}
