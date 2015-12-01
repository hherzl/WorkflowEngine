using System;
using System.Runtime.Serialization;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowBatchViewModel
    {
        public WorkflowBatchViewModel()
        {

        }

        [DataMember(Name = "name")]
        public String Name { get; set; }
    }
}
