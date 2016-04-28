using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowBatchSingleResponse : ViewModelResponse, ISingleViewModelResponse<WorkflowBatchViewModel>
    {
        public WorkflowBatchSingleResponse()
        {

        }

        [DataMember(Name = "model")]
        public WorkflowBatchViewModel Model { get; set; }
    }
}
