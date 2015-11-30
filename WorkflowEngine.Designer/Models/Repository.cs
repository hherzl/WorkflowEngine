using System.Collections.Generic;
using System.Data.Entity;

namespace WorkflowEngine.Designer.Models
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;

            DbSet = dbContext.Set<TEntity>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }
    }
}
