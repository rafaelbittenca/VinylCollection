using System.Collections.Generic;
using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
    public interface IRecordRepository : IGenericRepository<Record>
    {
        Record GetById(int id);
	  IEnumerable<Record> GetRecordsByArtist(int artistid);
    }
}
