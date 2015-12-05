using WorkflowEngine.Designer.Models;
using WorkflowEngine.Designer.Models.Contracts;

namespace WorkflowEngine.Designer.Services
{
    public class UowService : IUowService
    {
        public IWorkflowManagerUow GetWorkflowManagerUow()
        {
            return new WorkflowManagerUow(new WorkflowEngineDbContext());
        }
    }
}
