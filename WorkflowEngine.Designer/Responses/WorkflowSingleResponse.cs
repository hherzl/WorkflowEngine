using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class WorkflowSingleResponse : ViewModelResponse, ISingleViewModelResponse<WorkflowViewModel>
    {
        public WorkflowSingleResponse()
        {

        }

        [DataMember(Name = "model")]
        public WorkflowViewModel Model { get; set; }
    }
}
