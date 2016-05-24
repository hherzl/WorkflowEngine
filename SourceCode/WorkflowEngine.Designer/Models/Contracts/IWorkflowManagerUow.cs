namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IWorkflowManagerUow : IUow
    {
        IWorkflowBatchRepository WorkflowBatchRepository { get; }

        IWorkflowConstantRepository WorkflowConstantRepository { get; }

        IWorkflowRepository WorkflowRepository { get; }

        IWorkflowTaskRepository WorkflowTaskRepository { get; }
    }
}
