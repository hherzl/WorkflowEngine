using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowTaskComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowTaskViewModel>
    {
        public WorkflowTaskComposedResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<WorkflowTaskViewModel> Model { get; set; }
    }
}
