using System.Data.Entity;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowManagerUow : IWorkflowManagerUow
    {
        private DbContext m_dbContext;

        private IWorkflowBatchRepository m_workflowBatchRepository;
        private IWorkflowRepository m_workflowRepository;
        private IWorkflowTaskRepository m_workflowTaskRepository;

        public WorkflowManagerUow(DbContext dbContext)
        {
            m_dbContext = dbContext;
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
