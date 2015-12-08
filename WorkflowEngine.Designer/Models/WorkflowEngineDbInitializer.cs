using System.Data.Entity;
using WorkflowEngine.Model;
using WorkflowEngine.Model.Mocking;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowEngineDbInitializer : DropCreateDatabaseAlways<WorkflowEngineDbContext>
    {
        protected override void Seed(WorkflowEngineDbContext context)
        {
            var workflowConstantDbSet = context.Set<WorkflowConstant>();

            foreach (var item in WorkflowEngineMock.GetConstants())
            {
                workflowConstantDbSet.Add(item);
            }

            var workflowBatchDbSet = context.Set<WorkflowBatch>();

            foreach (var item in WorkflowEngineMock.GetBatches())
            {
                workflowBatchDbSet.Add(item);
            }

            var workflowDbSet = context.Set<Workflow>();

            foreach (var item in WorkflowEngineMock.GetWorkflows())
            {
                workflowDbSet.Add(item);
            }

            var workflowTaskDbSet = context.Set<WorkflowTask>();

            foreach (var item in WorkflowEngineMock.GetTasks())
            {
                workflowTaskDbSet.Add(item);
            }

            base.Seed(context);
        }
    }
}
