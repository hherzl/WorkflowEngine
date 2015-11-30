using System.Collections.Generic;

namespace WorkflowEngine.Designer.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
