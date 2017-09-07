using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Artist GetById(long? id);
    }
}
