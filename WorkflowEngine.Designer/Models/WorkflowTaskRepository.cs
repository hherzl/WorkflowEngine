using System.Data.Entity;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowTaskRepository : Repository<WorkflowTask>, IWorkflowTaskRepository
    {
        public WorkflowTaskRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
