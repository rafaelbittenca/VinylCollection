using System.Data.Entity;
using System.Linq;
using Vinyl.DAL.Contract;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(DbContext context)
            :base(context)
        {

        }

        public Record GetById(int id)
        {
            return Find(x => x.ID == id).FirstOrDefault();
        }
    }
}
