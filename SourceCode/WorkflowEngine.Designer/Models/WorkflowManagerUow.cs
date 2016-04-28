using System;
using System.Data.Entity;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Models.Repositories;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowManagerUow : Uow, IWorkflowManagerUow
    {
        private Boolean Disposed;
        private IWorkflowBatchRepository m_workflowBatchRepository;
        private IWorkflowConstantRepository m_workflowConstantRepository;
        private IWorkflowRepository m_workflowRepository;
        private IWorkflowTaskRepository m_workflowTaskRepository;

        public WorkflowManagerUow(DbContext dbContext)
            : base(dbContext)
        {
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public IWorkflowBatchRepository WorkflowBatchRepository
        {
            get
            {
                return m_workflowBatchRepository ?? (m_workflowBatchRepository = new WorkflowBatchRepository(DbContext));
            }
        }

        public IWorkflowConstantRepository WorkflowConstantRepository
        {
            get
            {
                return m_workflowConstantRepository ?? (m_workflowConstantRepository = new WorkflowConstantRepository(DbContext));
            }
        }

        public IWorkflowRepository WorkflowRepository
        {
            get
            {
                return m_workflowRepository ?? (m_workflowRepository = new WorkflowRepository(DbContext));
            }
        }

        public IWorkflowTaskRepository WorkflowTaskRepository
        {
            get
            {
                return m_workflowTaskRepository ?? (m_workflowTaskRepository = new WorkflowTaskRepository(DbContext));
            }
        }
    }
}
