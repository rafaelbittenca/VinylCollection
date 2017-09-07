using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public T Get(int? id)                    // ?? Revisar
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return _entities.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetAll()    // ?? Revisar
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
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return _entities.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {

            return _entities.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().SingleOrDefault(predicate);
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
