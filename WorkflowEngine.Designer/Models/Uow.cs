using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models
{
    public class Uow
    {
        protected DbContext m_dbContext;

        public Uow(DbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public Int32 CommitChanges()
        {
            return m_dbContext.SaveChanges();
        }

        public Task<Int32> CommitChangesAsync()
        {
            return m_dbContext.SaveChangesAsync();
        }
    }
}
