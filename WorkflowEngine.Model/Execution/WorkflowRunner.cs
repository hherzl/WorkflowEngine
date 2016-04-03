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

        public event StartProcessWorkflow StartProcessWorkflow;

        public event ProcessWorkflow ProcessWorkflow;

        public event EndProcessWorkflow EndProcessWorkflow;

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
                if (StartProcessWorkflow != null)
                {
                    StartProcessWorkflow(this, new ProcessWorkflowEventArgs(workflow));
                }

                var result = new ExecutionResult
                {
                    WorkflowName = workflow.Name,
                    ExecutedTasks = new List<String>()
                };

                if (ProcessWorkflow != null)
                {
                    ProcessWorkflow(this, new ProcessWorkflowEventArgs(workflow));
                }

                foreach (var workflowTask in workflow.Tasks)
                {
                    result.ExecutedTasks.Add(workflowTask.Name);

                    foreach (var workflowParameter in workflowTask.Parameters)
                    {

                    }

                    System.Threading.Thread.Sleep(5000);
                }

                if (EndProcessWorkflow != null)
                {
                    EndProcessWorkflow(this, new ProcessWorkflowEventArgs(workflow));
                }

                result.Succeeded = true;

                executionSummary.Results.Add(result);
            }

            return executionSummary;
        }
    }
}
