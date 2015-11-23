using System;
using System.Collections.Generic;

namespace WorkflowEngine.Model
{
    public class Workflow
    {
        public Workflow()
        {

        }

        public String Name { get; set; }

        public String Description { get; set; }

        private List<WorkflowTask> m_tasks;
        private List<WorkflowExpectedResult> m_expectedResults;

        public List<WorkflowTask> Tasks
        {
            get
            {
                return m_tasks ?? (m_tasks = new List<WorkflowTask>());
            }
            set
            {
                m_tasks = value;
            }
        }

        public List<WorkflowExpectedResult> ExpectedResults
        {
            get
            {
                return m_expectedResults ?? (m_expectedResults = new List<WorkflowExpectedResult>());
            }
            set
            {
                m_expectedResults = value;
            }
        }
    }
}
