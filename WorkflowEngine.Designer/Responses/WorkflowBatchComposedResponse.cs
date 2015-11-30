using System.Collections.Generic;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowBatchComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowBatchViewModel>
    {
        public WorkflowBatchComposedResponse()
        {

        }

        public IEnumerable<WorkflowBatchViewModel> Model { get; set; }
    }
}
