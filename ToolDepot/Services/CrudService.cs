using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToolDepot.Data;

namespace ToolDepot.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, new()
    {
        protected IRepository<T> repo;

        public CrudService(IRepository<T> repo)
        {
            this.repo = repo;
        }


        public virtual T GetById(int id)
        {
            if (id == 0)
                return null;
            return repo.GetById(id);

        }

        public virtual IEnumerable<T> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public virtual T Get(Expression<Func<T, bool>> @where)
        {
            return repo.Get(where);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> @where)
        {
            return repo.GetMany(where);
        }



        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).ToString());
            repo.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).ToString());
            repo.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).ToString());
            repo.Delete(entity);
        }
        public virtual void AddOrUpdate(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(typeof(T).ToString());
            repo.AddOrUpdate(entity);
        }

    }
}
