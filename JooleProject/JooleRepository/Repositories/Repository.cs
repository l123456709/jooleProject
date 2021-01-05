using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository.Repositories
{   
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class;
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}