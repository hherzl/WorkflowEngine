using System.Collections.Generic;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowTaskComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowTaskViewModel>
    {
        public WorkflowTaskComposedResponse()
        {

        }

        public IEnumerable<WorkflowTaskViewModel> Model { get; set; }
    }
}
