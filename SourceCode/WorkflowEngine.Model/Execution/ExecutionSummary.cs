using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowEngine.Model.Validation;

namespace WorkflowEngine.Model.Execution
{
    public class ExecutionSummary
    {
        public ExecutionSummary()
        {
            ExecutionDateTime = DateTime.Now;
        }

        public DateTime ExecutionDateTime { get; set; }

        private List<WorkflowValidationMessage> m_validationMessages;
        private List<ExecutionResult> m_results;

        public List<WorkflowValidationMessage> ValidationMessages
        {
            get
            {
                return m_validationMessages ?? (m_validationMessages = new List<WorkflowValidationMessage>());
            }
            set
            {
                m_validationMessages = value;
            }
        }

        public List<ExecutionResult> Results
        {
            get
            {
                return m_results ?? (m_results = new List<ExecutionResult>());
            }
            set
            {
                m_results = value;
            }
        }

        public Int32 ExecutedCount
        {
            get
            {
                return Results.Count;
            }
        }

        public Int32 SuccessCount
        {
            get
            {
                return Results.Where(item => item.Succeeded).Count();
            }
        }

        public Int32 FailedCount
        {
            get
            {
                return Results.Where(item => item.Failed).Count();
            }
        }

        public Int32 KnownIssueCount
        {
            get
            {
                return Results.Where(item => item.KnownIssue).Count();
            }
        }
    }
}
