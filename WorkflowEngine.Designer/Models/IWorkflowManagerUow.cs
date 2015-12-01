namespace WorkflowEngine.Designer.Models
{
    public interface IWorkflowManagerUow : IUow
    {
        IWorkflowBatchRepository WorkflowBatchRepository { get; }

        IWorkflowRepository WorkflowRepository { get; }

        IWorkflowTaskRepository WorkflowTaskRepository { get; }
    }
}
