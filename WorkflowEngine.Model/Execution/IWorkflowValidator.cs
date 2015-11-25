using System.Collections.Generic;

namespace WorkflowEngine.Model.Execution
{
    public interface IWorkflowValidator
    {
        IEnumerable<WorkflowValidationMessage> Validate(WorkflowBatch workflowBatch);
    }
}
