using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToolDepot.Services
{
    public interface ICrudService<T> where T : class, new()
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddOrUpdate(T entity);
    }
}
