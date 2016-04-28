using System.ComponentModel.DataAnnotations.Schema;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Mapping
{
    public class WorkflowTaskMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<WorkflowTask>
    {
        public WorkflowTaskMap()
        {
            ToTable("WorkflowTask");

            HasKey(p => new { p.ID });

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(p => p.Parameters);
        }
    }
}
