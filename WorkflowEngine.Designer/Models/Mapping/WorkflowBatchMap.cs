using System.ComponentModel.DataAnnotations.Schema;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Mapping
{
    public class WorkflowBatchMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<WorkflowBatch>
    {
        public WorkflowBatchMap()
        {
            ToTable("WorkflowBatch");

            HasKey(p => new { p.ID });

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(p => p.Constants);
            Ignore(p => p.Variables);
            Ignore(p => p.Workflows);
        }
    }
}
