using System.Data.Entity;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowRepository : Repository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
