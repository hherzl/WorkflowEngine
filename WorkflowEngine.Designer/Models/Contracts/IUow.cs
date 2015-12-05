using System;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IUow
    {
        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
