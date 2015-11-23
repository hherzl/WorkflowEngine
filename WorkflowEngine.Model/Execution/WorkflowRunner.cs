using System;
using System.Collections.Generic;

namespace WorkflowEngine.Model.Execution
{
    public class WorkflowRunner
    {
        public WorkflowRunner(WorkflowBatch batch)
        {
            WorkflowBatch = batch;
        }

        public WorkflowBatch WorkflowBatch { get; protected set; }

        public ExecutionSummary Execute()
        {
            var executionSummary = new ExecutionSummary();

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
