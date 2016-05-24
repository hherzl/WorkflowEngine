using System;
using System.Data.Entity;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Models.Repositories;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowManagerUow : Uow, IWorkflowManagerUow
    {
        private IWorkflowBatchRepository m_workflowBatchRepository;
        private IWorkflowConstantRepository m_workflowConstantRepository;
        private IWorkflowRepository m_workflowRepository;
        private IWorkflowTaskRepository m_workflowTaskRepository;

        public WorkflowManagerUow(DbContext dbContext)
            : base(dbContext)
        {
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
