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
                .FirstOrDefault(item => item.ID == entity.ID);
        }
    }
}
