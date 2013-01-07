using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToolDepot.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IRepository<T> where T : class 
    {


        T GetById(object id);

        IEnumerable<T> GetAll();
       
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
 
        //
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        void AddOrUpdate(T entity);

        IQueryable<T> Table { get; }
        IDbContext Context { get;}

    }
}
