using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models
{
    public abstract class Uow
    {
        protected readonly DbContext DbContext;
        protected Boolean Disposed;

        public Uow(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public DbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

        public Int32 CommitChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task<Int32> CommitChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
