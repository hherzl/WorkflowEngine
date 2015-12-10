using System;
using System.Collections.Generic;
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

            if (entity.Workflows != null && entity.Workflows.Count > 0)
            {
                Workflows = new List<WorkflowViewModel>();

                foreach (var item in entity.Workflows)
                {
                    Workflows.Add(new WorkflowViewModel(item));
                }
            }
        }

        [DataMember(Name = "id")]
        public Int32? ID { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }

        [DataMember(Name = "workflows")]
        public List<WorkflowViewModel> Workflows { get; set; }

        public WorkflowBatch ToEntity()
        {
            return new WorkflowBatch { ID = ID, Name = Name, Description = Description };
        }
    }
}
