namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IWorkflowManagerUow : IUow
    {
        IWorkflowBatchRepository WorkflowBatchRepository { get; }

        IWorkflowRepository WorkflowRepository { get; }

        IWorkflowTaskRepository WorkflowTaskRepository { get; }
    }
}
