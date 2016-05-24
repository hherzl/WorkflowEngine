using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models.Contracts
{
    public interface IUow : IDisposable
    {
        DbContextTransaction BeginTransaction();

        Int32 CommitChanges();

        Task<Int32> CommitChangesAsync();
    }
}
