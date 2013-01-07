using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using ToolDepot.Data.Mapping.Logging;


namespace ToolDepot.Data
{
    public class AppContext : DbContext, IDbContext
    {
        public AppContext()
            : base("AppContext")
        {
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            //dynamically load all configuration
            System.Type configType = typeof(LogMap);   //any of your configuration classes here
            var typesToRegister = Assembly.GetAssembly(configType).GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            //modelBuilder.Configurations.Add(new CustomerMap());
            //modelBuilder.Configurations.Add(new UserRoleMap());

            base.OnModelCreating(modelBuilder);

        }

        public IEnumerable<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return base.Database.SqlQuery<TEntity>(sql, parameters);
        }

        public IEnumerable<TEntity> SqlQuery<TEntity>(SqlWrap spWrap) where TEntity : class
        {
            return SqlQuery<TEntity>(spWrap.Sql, spWrap.Parameters.Cast<object>().ToArray());
        }
        public Database MyDb
        {

            get { return base.Database; }

        }
    }
}