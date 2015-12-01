using System;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models
{
    public interface IUow
    {
        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
