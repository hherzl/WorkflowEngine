using System.Data.Entity;
using System.Linq;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
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
                .FirstOrDefault(item => item.ID == entity.ID);
        }
    }
}
