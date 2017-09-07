using System;

namespace Vinyl.DAL.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IRecordRepository Records { get; }
        IAuthenticationRepository Auths { get; }   
        IUserRepository Users { get; }             

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Complete();
    }
}
