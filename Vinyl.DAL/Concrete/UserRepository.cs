using System.Data.Entity;
using System.Linq;
using Vinyl.DAL.Contract;
using Vinyl.Libraries.Security;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {

        }

        public User GetById(int id)
        {
            return Find(x => x.ID == id).FirstOrDefault();
        }

        public override void Add(User entity)
        {
            entity.Password = CustomEncrypt.Encrypt(entity.Password);             
            base.Add(entity);
        }
    }
}
