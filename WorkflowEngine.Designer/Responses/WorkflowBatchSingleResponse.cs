using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowBatchSingleResponse : ViewModelResponse, ISingleViewModelResponse<WorkflowBatchViewModel>
    {
        public WorkflowBatchSingleResponse()
        {

        }

        public WorkflowBatchViewModel Model { get; set; }
    }
}
