using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowEngine.Model.Validation
{
    public class UnreferencedConstantValidator : IWorkflowValidator
    {
        public UnreferencedConstantValidator()
        {

        }

        public IEnumerable<WorkflowValidationMessage> Validate(WorkflowBatch workflowBatch)
        {
            foreach (var constant in workflowBatch.Constants)
            {
                foreach (var variable in workflowBatch.Variables)
                {
                    if (workflowBatch.Variables.Where(item => item.ConstantName == constant.Name).Count() == 0)
                    {
                        yield return new WorkflowValidationMessage
                        {
                            MessageType = WorkflowValidationMessageType.Warning,
                            WorkflowBatchName = workflowBatch.Name,
                            Message = String.Format("Constant in variable with name: '{0}' doesn't have any reference in tasks' parameters", constant.Name)
                        };
                    }
                }
            }

            foreach (var constant in workflowBatch.Constants)
            {
                foreach (var workflow in workflowBatch.Workflows)
                {
                    foreach (var task in workflow.Tasks)
                    {
                        if (task.Parameters.Where(item => item.Constant == constant.Name).Count() == 0)
                        {
                            yield return new WorkflowValidationMessage
                            {
                                WorkflowBatchName = workflowBatch.Name,
                                WorkflowTaskName = task.Name,
                                MessageType = WorkflowValidationMessageType.Warning,
                                WorkflowName = workflow.Name,
                                Message = String.Format("Constant with name: '{0}' doesn't have any reference in tasks' parameters", constant.Name)
                            };
                        }
                    }
                }
            }
        }
    }
}
