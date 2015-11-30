using System.Collections.Generic;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowViewModel>
    {
        public WorkflowComposedResponse()
        {

        }

        public IEnumerable<WorkflowViewModel> Model { get; set; }
    }
}
