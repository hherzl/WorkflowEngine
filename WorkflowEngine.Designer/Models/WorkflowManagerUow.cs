using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowManagerUow : Uow, IWorkflowManagerUow
    {
        private IWorkflowBatchRepository m_workflowBatchRepository;
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
                return m_workflowBatchRepository ?? (m_workflowBatchRepository = new WorkflowBatchRepository(m_dbContext));
            }
        }

        public IWorkflowRepository WorkflowRepository
        {
            get
            {
                return m_workflowRepository ?? (m_workflowRepository = new WorkflowRepository(m_dbContext));
            }
        }

        public IWorkflowTaskRepository WorkflowTaskRepository
        {
            get
            {
                return m_workflowTaskRepository ?? (m_workflowTaskRepository = new WorkflowTaskRepository(m_dbContext));
            }
        }
    }
}
