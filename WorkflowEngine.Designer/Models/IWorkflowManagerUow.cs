namespace WorkflowEngine.Designer.Models
{
    public interface IWorkflowManagerUow
    {
        IWorkflowBatchRepository WorkflowBatchRepository { get; }

        IWorkflowRepository WorkflowRepository { get; }

        IWorkflowTaskRepository WorkflowTaskRepository { get; }
    }
}
