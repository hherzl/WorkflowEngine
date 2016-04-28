using System.Data.Entity;
using System.Linq;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Repositories
{
    public class WorkflowRepository : Repository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Workflow Get(Workflow entity)
        {
            return DbSet
                .FirstOrDefault(item => item.ID == entity.ID);
        }
    }
}
