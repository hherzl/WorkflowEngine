using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowConstantComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowConstantViewModel>
    {
        public WorkflowConstantComposedResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<WorkflowConstantViewModel> Model { get; set; }
    }
}
