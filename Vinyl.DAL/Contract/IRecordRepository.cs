using System.Collections.Generic;
using System.Threading.Tasks;
using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
	public interface IRecordRepository : IGenericRepository<Record>
	{
		Record GetById(int id);
		IEnumerable<Record> GetRecordsByArtist(int artistid);

		Task<Record> GetByIdAsync(int id);
		Task<IEnumerable<Record>> GetRecordsByArtistAsync(int artistid);
	}
}
