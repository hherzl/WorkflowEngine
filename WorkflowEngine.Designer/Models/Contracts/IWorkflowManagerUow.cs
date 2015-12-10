using System.Data.Entity;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IWorkflowManagerUow : IUow
    {
        DbContext DbContext { get; }

        IWorkflowBatchRepository WorkflowBatchRepository { get; }

        IWorkflowConstantRepository WorkflowConstantRepository { get; }

        IWorkflowRepository WorkflowRepository { get; }

        IWorkflowTaskRepository WorkflowTaskRepository { get; }
    }
}
