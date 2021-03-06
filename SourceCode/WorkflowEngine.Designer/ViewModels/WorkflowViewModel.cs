﻿using System;
using System.Runtime.Serialization;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowViewModel
    {
        public WorkflowViewModel()
        {

        }

        public WorkflowViewModel(Workflow entity)
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

        [DataMember(Name = "workflowBatchID")]
        public Int32? WorkflowBatchID { get; set; }

        public Workflow ToEntity()
        {
            return new Workflow { ID = ID, Name = Name, Description = Description, WorkflowBatchID = WorkflowBatchID };
        }
    }
}
