using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowEngine.Model.Validation
{
    public class UndefinedConstantValidator : IWorkflowValidator
    {
        public IEnumerable<WorkflowValidationMessage> Validate(WorkflowBatch workflowBatch)
        {
            foreach (var workflow in workflowBatch.Workflows)
            {
                foreach (var task in workflow.Tasks)
                {
                    foreach (var parameter in task.Parameters)
                    {
                        if (!String.IsNullOrEmpty(parameter.Constant))
                        {
                            if (workflowBatch.Constants.Where(item => item.Name == parameter.Constant).Count() == 0)
                            {
                                yield return new WorkflowValidationMessage
                                {
                                    MessageType = WorkflowValidationMessageType.Error,
                                    WorkflowName = workflow.Name,
                                    Message = String.Format("There is not a definition for constant with name: '{0}'", parameter.Constant)
                                };
                            }
                        }
                    }
                }
            }
        }
    }
}
