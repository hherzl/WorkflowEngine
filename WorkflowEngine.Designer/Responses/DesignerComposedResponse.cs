using System.Collections.Generic;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    public class DesignerComposedResponse : ViewModelResponse, IComposedViewModelResponse<DesignerViewModel>
    {
        public DesignerComposedResponse()
        {

        }

        public IEnumerable<DesignerViewModel> Model { get; set; }
    }
}
