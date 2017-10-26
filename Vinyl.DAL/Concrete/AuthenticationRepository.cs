using System.Data.Entity;
using System.Linq;
using Vinyl.DAL.Contract;
using Vinyl.Libraries.Security;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
	public class AuthenticationRepository : GenericRepository<User>, IAuthenticationRepository
	{
		public AuthenticationRepository(DbContext context)
		    : base(context)
		{

		}
		public bool Authenticate(string username, string password)
		{
			//var senha = CustomEncrypt.Encrypt(password);
			//var result = Find(u => u.Email == username && u.Password == senha).FirstOrDefault();
			var result = Find(u => u.Email == username && u.Password == password).FirstOrDefault();
			if (result == null)
				return false;
			return true;
		}

		public bool IsUser(string email)
		{
			var result = Find(u => u.Email == email).FirstOrDefault();
			if (result == null)
				return false;
			return true;
		}

		public bool Logout()
		{
			return true;
		}

	}
}
