using WorkflowEngine.Designer.Models;

namespace WorkflowEngine.Designer.Services
{
    public interface IUowService
    {
        IWorkflowManagerUow GetWorkflowManagerUow();
    }
}
