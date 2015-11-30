using System;
using System.Collections.Generic;

namespace WorkflowEngine.Model
{
    public class WorkflowTask
    {
        public WorkflowTask()
        {

        }

        public Int32? ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        private List<WorkflowParameter> m_parameters;

        public List<WorkflowParameter> Parameters
        {
            get
            {
                return m_parameters ?? (m_parameters = new List<WorkflowParameter>());
            }
            set
            {
                m_parameters = value;
            }
        }
    }
}
