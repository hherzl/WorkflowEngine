using WorkflowEngine.Designer.Models;

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
