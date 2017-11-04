using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vinyl.Contracts
{
	public interface IGenericRepository<T> where T : IEntity
	{
		T Get(int? id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		T SingleOrDefault(Expression<Func<T, bool>> predicate);

		Task<T> GetAsync(int? id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
		Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

		void Add(T entity);
		void AddRange(IEnumerable<T> entities);

		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		void Edit(T entity);
	}
}
