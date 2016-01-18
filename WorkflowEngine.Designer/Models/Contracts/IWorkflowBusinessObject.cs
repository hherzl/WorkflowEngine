using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IWorkflowBusinessObject : IBusinessObject
    {
        Task<IEnumerable<WorkflowBatch>> GetWorkflowBatches();

        Task<WorkflowBatch> GetWorkflowBatch(WorkflowBatch entity);

        Task<WorkflowBatch> AddWorkflowBatch(WorkflowBatch entity);

        Task<WorkflowBatch> UpdateWorkflowBatch(Int32 id, WorkflowBatch changes);

        Task<WorkflowBatch> DeleteWorkflowBatch(Int32 id, WorkflowBatch changes);

        Task<WorkflowBatch> CloneWorkflowBatch(Int32 id);

        Task<IEnumerable<Workflow>> GetWorkflows();

        Task<Workflow> GetWorkflow(Workflow entity);

        Task<Workflow> AddWorkflow(Workflow entity);

        Task<Workflow> UpdateWorkflow(Int32 id, Workflow changes);

        Task<IEnumerable<WorkflowTask>> GetWorkflowTasks();

        Task<IEnumerable<WorkflowConstant>> GetWorkflowConstants();
    }
}
