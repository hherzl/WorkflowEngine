using System;
using System.Runtime.Serialization;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowTaskViewModel
    {
        public WorkflowTaskViewModel()
        {

        }

        [DataMember(Name = "id")]
        public Int32? ID { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }
    }
}
