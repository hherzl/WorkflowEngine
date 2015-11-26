using System.Collections.Generic;

namespace WorkflowEngine.Model.Validation
{
    public interface IWorkflowValidator
    {
        IEnumerable<WorkflowValidationMessage> Validate(WorkflowBatch workflowBatch);
    }
}
