using System.ComponentModel.DataAnnotations.Schema;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Mapping
{
    public class WorkflowConstantMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<WorkflowConstant>
    {
        public WorkflowConstantMap()
        {
            ToTable("WorkflowConstant");

            HasKey(p => new { p.ID });

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
