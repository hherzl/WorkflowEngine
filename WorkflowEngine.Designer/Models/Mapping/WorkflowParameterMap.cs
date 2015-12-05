using System.ComponentModel.DataAnnotations.Schema;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Mapping
{
    public class WorkflowParameterMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<WorkflowParameter>
    {
        public WorkflowParameterMap()
        {
            ToTable("WorkflowParameter");

            HasKey(p => new { p.ID });

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
