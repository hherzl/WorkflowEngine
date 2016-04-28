using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowViewModel>
    {
        public WorkflowComposedResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<WorkflowViewModel> Model { get; set; }
    }
}
