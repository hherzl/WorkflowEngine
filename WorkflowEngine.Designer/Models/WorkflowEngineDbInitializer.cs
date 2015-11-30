using System.Data.Entity;
using WorkflowEngine.Model;
using WorkflowEngine.Model.Mocking;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowEngineDbInitializer : DropCreateDatabaseAlways<WorkflowEngineDbContext>
    {
        protected override void Seed(WorkflowEngineDbContext context)
        {
            var workflowTaskDbSet = context.Set<WorkflowTask>();

            foreach (var item in WorkflowEngineMock.GetTasks())
            {
                workflowTaskDbSet.Add(item);
            }

            base.Seed(context);
        }
    }
}
