using System.Data.Entity;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Repositories
{
    public class WorkflowTaskRepository : Repository<WorkflowTask>, IWorkflowTaskRepository
    {
        public WorkflowTaskRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
