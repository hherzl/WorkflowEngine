using System;
using System.Collections.Generic;

namespace WorkflowEngine.Model
{
    public class WorkflowBatch
    {
        public WorkflowBatch()
        {

        }

        public String Description { get; set; }

        private List<WorkflowConstant> m_constants;
        private List<WorkflowVariable> m_variables;
        private List<Workflow> m_workflows;

        public List<WorkflowConstant> Constants
        {
            get
            {
                return m_constants ?? (m_constants = new List<WorkflowConstant>());
            }
            set
            {
                m_constants = value;
            }
        }

        public List<WorkflowVariable> Variables
        {
            get
            {
                return m_variables ?? (m_variables = new List<WorkflowVariable>());
            }
            set
            {
                m_variables = value;
            }
        }

        public List<Workflow> Workflows
        {
            get
            {
                return m_workflows ?? (m_workflows = new List<Workflow>());
            }
            set
            {
                m_workflows = value;
            }
        }
    }
}
