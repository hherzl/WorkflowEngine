using System.Data.Entity;
using System.Linq;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models.Repositories
{
    public class WorkflowConstantRepository : Repository<WorkflowConstant>, IWorkflowConstantRepository
    {
        public WorkflowConstantRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override WorkflowConstant Get(WorkflowConstant entity)
        {
            return DbSet
                .FirstOrDefault(item => item.ID == entity.ID);
        }
    }
}
