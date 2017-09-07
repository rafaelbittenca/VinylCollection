using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Contract
{
    public interface IAuthenticationRepository : IGenericRepository<User>
    {
        bool Authenticate(string username, string password);
        bool Logout();
        bool IsUser(string email);
    }
}
