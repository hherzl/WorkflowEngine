using System.Data.Entity;
using WorkflowEngine.Designer.Models.Mapping;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowEngineDbContext : System.Data.Entity.DbContext
    {
        public WorkflowEngineDbContext()
            : base("WorkflowEngineConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;

            System.Data.Entity.Database.SetInitializer<WorkflowEngineDbContext>(new WorkflowEngineDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WorkflowBatchMap());
            modelBuilder.Configurations.Add(new WorkflowMap());
            modelBuilder.Configurations.Add(new WorkflowTaskMap());
            modelBuilder.Configurations.Add(new WorkflowParameterMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
