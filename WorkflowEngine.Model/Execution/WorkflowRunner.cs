using System;
using System.Collections.Generic;
using WorkflowEngine.Model.Validation;

namespace WorkflowEngine.Model.Execution
{
    public class WorkflowRunner
    {
        public WorkflowRunner(WorkflowBatch batch)
        {
            WorkflowBatch = batch;

            Validators = new List<IWorkflowValidator>()
            {
                new UndefinedConstantValidator(),
                new UnreferencedConstantValidator()
            };
        }

        public WorkflowBatch WorkflowBatch { get; protected set; }

        public List<IWorkflowValidator> Validators { get; set; }

        public ExecutionSummary Execute()
        {
            var executionSummary = new ExecutionSummary();

            if (Validators != null)
            {
                foreach (var validator in Validators)
                {
                    executionSummary.ValidationMessages.AddRange(validator.Validate(WorkflowBatch));
                }
            }

            foreach (var workflow in WorkflowBatch.Workflows)
            {
                var result = new ExecutionResult
                {
                    WorkflowName = workflow.Name,
                    ExecutedTasks = new List<String>()
                };

                foreach (var workflowTask in workflow.Tasks)
                {
                    result.ExecutedTasks.Add(workflowTask.Name);

                    foreach (var workflowParameter in workflowTask.Parameters)
                    {

                    }
                }

                result.Succeeded = true;

                executionSummary.Results.Add(result);
            }

            return executionSummary;
        }
    }
}
