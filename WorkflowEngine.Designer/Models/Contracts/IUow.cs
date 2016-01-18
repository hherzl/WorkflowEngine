using System;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IUow : IDisposable
    {
        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
