using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vinyl.Contracts;
using Vinyl.Models;

namespace Vinyl.DAL.Concrete
{
	public abstract class GenericRepository<T> : IGenericRepository<T>
		    where T : Entity
	{
		protected DbContext _entities;

		public GenericRepository(DbContext context)
		{
			_entities = context;
		}

		public T Get(int? id)
		{
			return _entities.Set<T>().Find(id);
		}

		public async Task<T> GetAsync(int? id)
		{
			return await _entities.Set<T>().FindAsync(id);
		}

		public virtual IEnumerable<T> GetAll()    
		{

			// Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
			// too much noise. I could get a reference to the DbSet returned from this method in the 
			// constructor and store it in a private field like _entities. This way, the implementation
			// of our methods would be cleaner:
			// 
			// _entities.ToList();
			// _entities.Where();
			// _entities.SingleOrDefault();
			// 
			// Feel free to change this on your own.
			//
			return _entities.Set<T>().ToList();
		}

		public async virtual Task<IEnumerable<T>> GetAllAsync()   
		{
			return await _entities.Set<T>().ToListAsync();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{

			return _entities.Set<T>().Where(predicate);
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
		{

			return await _entities.Set<T>().Where(predicate).ToListAsync();
		}

		public T SingleOrDefault(Expression<Func<T, bool>> predicate)
		{
			return _entities.Set<T>().SingleOrDefault(predicate);
		}

		public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
		{
			return await _entities.Set<T>().SingleOrDefaultAsync(predicate);
		}



		public virtual void Add(T entity)
		{
			_entities.Set<T>().Add(entity);
		}

		public virtual void AddRange(IEnumerable<T> entities)
		{
			_entities.Set<T>().AddRange(entities);
		}

		public void Remove(T entity)
		{
			_entities.Set<T>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_entities.Set<T>().RemoveRange(entities);
		}

		public virtual void Edit(T entity)
		{
			_entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
		}
	}
}
