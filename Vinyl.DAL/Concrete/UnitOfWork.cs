using System;
using System.Data.Entity;
using Vinyl.DAL.Contract;

namespace Vinyl.DAL.Concrete
{
	/// <summary>
	/// The Entity Framework implementation of IUnitOfWork
	/// </summary>
	public sealed class UnitOfWork : IUnitOfWork
    {
	  /// <summary>
	  /// The DbContext
	  /// </summary>
	  private DbContext _dbContext;

	  /// <summary>
	  /// Initializes a new instance of the UnitOfWork class.
	  /// </summary>
	  /// <param name="context">The object context</param>
	  public UnitOfWork(DbContext context)
	  {
		_dbContext = context;

		Artists = new ArtistRepository(_dbContext);
		Records = new RecordRepository(_dbContext);

		Users = new UserRepository(_dbContext);             //RV
		Auths = new AuthenticationRepository(_dbContext);   //RV
	  }

	  public IArtistRepository Artists { get; private set; }

	  public IRecordRepository Records { get; private set; }

	  public IAuthenticationRepository Auths { get; private set; }    //RV
	  public IUserRepository Users { get; private set; }              //RV
	  /// <summary>
	  /// Saves all pending changes
	  /// </summary>
	  /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
	  public int Complete()
	  {
		// Save changes with the default options
		return _dbContext.SaveChanges();
	  }

	  /// <summary>
	  /// Disposes the current object
	  /// </summary>
	  public void Dispose()
	  {
		Dispose(true);
		GC.SuppressFinalize(this);
	  }

	  /// <summary>
	  /// Disposes all external resources.
	  /// </summary>
	  /// <param name="disposing">The dispose indicator.</param>
	  private void Dispose(bool disposing)
	  {
		if (disposing)
		{
		    if (_dbContext != null)
		    {
			  _dbContext.Dispose();
			  _dbContext = null;
		    }
		}
	  }
    }
}
