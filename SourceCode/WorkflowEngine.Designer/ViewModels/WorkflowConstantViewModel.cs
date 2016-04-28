using System;
using System.Runtime.Serialization;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowConstantViewModel
    {
        public WorkflowConstantViewModel()
        {

        }

        public WorkflowConstantViewModel(WorkflowConstant entity)
        {
            ID = entity.ID;
            Name = entity.Name;
            Description = entity.Description;
            Value = entity.Value;
        }

        [DataMember(Name = "id")]
        public Int32? ID { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }

        [DataMember(Name = "value")]
        public String Value { get; set; }
    }
}
