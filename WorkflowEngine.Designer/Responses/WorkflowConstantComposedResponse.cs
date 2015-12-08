using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class WorkflowConstantComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowConstantViewModel>
    {
        public WorkflowConstantComposedResponse()
        {

        }

        public IEnumerable<WorkflowConstantViewModel> Model { get; set; }
    }
}
