using System.Data.Entity;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowBatchRepository : Repository<WorkflowBatch>, IWorkflowBatchRepository
    {
        public WorkflowBatchRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
