using System;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.ViewModels
{
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

        public Int32? ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Workflow ToEntity()
        {
            return new Workflow
            {
                ID = ID,
                Name = Name,
                Description = Description
            };
        }
    }
}
