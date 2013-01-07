using System.Collections.Generic;
using System.Data.Entity;

namespace ToolDepot.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();


        /*
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();

        IList<TEntity> ExecuteStoredProcedureList1<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();
        */

        /*
	        var Id = new SqlParameter("@Id",5);
	        var Name = new SqlParameter("@Name","Happy");
	        var result = context.SqlQuery<ProcedureResult>("spTest @Id, @Name", Id, Name);
        */

        IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class;

        /*
            SqlWrap spWrap = new SqlWrap("spTest")
                .AddParam("Id", 5)
                .AddParam("Name", "happy");
            var result = context.SqlQuery<ProcedureResult>(spWrap);
        */
        IEnumerable<TEntity> SqlQuery<TEntity>(SqlWrap spWrap)  where TEntity : class;

    

    }
}