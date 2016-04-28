using System.Data.Entity;
using System.Linq;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Repositories
{
    public class WorkflowBatchRepository : Repository<WorkflowBatch>, IWorkflowBatchRepository
    {
        public WorkflowBatchRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override WorkflowBatch Get(WorkflowBatch entity)
        {
            return DbSet
                .Include(p => p.Workflows)
                .FirstOrDefault(item => item.ID == entity.ID);
        }
    }
}
