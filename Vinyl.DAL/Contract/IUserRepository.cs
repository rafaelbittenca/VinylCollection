using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetById(int id);
    }
}
