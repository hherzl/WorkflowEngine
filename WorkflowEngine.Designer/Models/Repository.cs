using System;
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

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Get(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {

        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
