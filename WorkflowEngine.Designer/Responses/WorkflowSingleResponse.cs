using System.Collections.Generic;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowSingleResponse : ViewModelResponse, ISingleViewModelResponse<WorkflowViewModel>
    {
        public WorkflowSingleResponse()
        {

        }

        public WorkflowViewModel Model { get; set; }
    }
}
