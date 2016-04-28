using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowBatchComposedResponse : ViewModelResponse, IComposedViewModelResponse<WorkflowBatchViewModel>
    {
        public WorkflowBatchComposedResponse()
        {

        }

        [DataMember(Name = "model")]
        public IEnumerable<WorkflowBatchViewModel> Model { get; set; }
    }
}
