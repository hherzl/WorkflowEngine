using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WorkflowEngine.Common;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.ViewModels
{
    [DataContract]
    public class WorkflowBatchViewModel
    {
        public WorkflowBatchViewModel()
        {

        }

        [DataMember(Name = "id")]
        public Int32? ID { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }

        [DataMember(Name = "workflows")]
        public List<WorkflowViewModel> Workflows { get; set; }
    }

    public static class WorkflowBatchMapper
    {
        public static WorkflowBatch ToEntity(this WorkflowBatchViewModel viewModel)
        {
            return viewModel.Map<WorkflowBatchViewModel, WorkflowBatch>();
        }

        public static WorkflowBatchViewModel ToViewModel(this WorkflowBatch viewModel)
        {
            return viewModel.Map<WorkflowBatch, WorkflowBatchViewModel>();
        }
    }
}
