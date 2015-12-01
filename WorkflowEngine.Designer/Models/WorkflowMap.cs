using System.ComponentModel.DataAnnotations.Schema;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Workflow>
    {
        public WorkflowMap()
        {
            ToTable("Workflow");

            HasKey(p => new { p.ID });

            Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(p => p.ExpectedResults);
        }
    }
}
