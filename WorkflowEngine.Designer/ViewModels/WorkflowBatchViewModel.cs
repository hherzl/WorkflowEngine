using System;
using System.Runtime.Serialization;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowBatchViewModel
    {
        public WorkflowBatchViewModel()
        {

        }

        public WorkflowBatchViewModel(WorkflowBatch entity)
        {
            ID = entity.ID;
            Name = entity.Name;
            Description = entity.Description;
        }

        [DataMember(Name = "id")]
        public Int32? ID { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }
    }
}
