using System;
using System.Collections.Generic;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IWorkflowBusinessObject : IBusinessObject
    {
        IEnumerable<WorkflowBatch> GetWorkflowBatches();

        WorkflowBatch GetWorkflowBatch(WorkflowBatch entity);

        WorkflowBatch AddWorkflowBatch(WorkflowBatch entity);

        WorkflowBatch UpdateWorkflowBatch(Int32 id, WorkflowBatch changes);

        WorkflowBatch DeleteWorkflowBatch(Int32 id, WorkflowBatch changes);

        WorkflowBatch CloneWorkflowBatch(Int32 id);

        IEnumerable<Workflow> GetWorkflows();

        Workflow GetWorkflow(Workflow entity);

        Workflow AddWorkflow(Workflow entity);

        Workflow UpdateWorkflow(Int32 id, Workflow changes);

        IEnumerable<WorkflowTask> GetWorkflowTasks();

        IEnumerable<WorkflowConstant> GetWorkflowConstants();
    }
}
