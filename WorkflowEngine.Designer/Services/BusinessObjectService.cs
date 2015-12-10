using WorkflowEngine.Designer.Models;
using WorkflowEngine.Designer.Models.Contracts;

namespace WorkflowEngine.Designer.Services
{
    public class BusinessObjectService : IBusinessObjectService
    {
        public IWorkflowBusinessObject GetBusinessObject()
        {
            return new WorkflowBusinessObject(new WorkflowManagerUow(new WorkflowEngineDbContext()));
        }
    }
}