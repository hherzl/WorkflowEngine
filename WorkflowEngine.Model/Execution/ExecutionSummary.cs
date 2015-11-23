using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WorkflowEngine.Model.Execution
{
    public class ExecutionSummary
    {
        public ExecutionSummary()
        {
            ExecutionDateTime = DateTime.Now;
        }

        public DateTime ExecutionDateTime { get; set; }

        private List<ExecutionResult> m_results;

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
            set
            {

            }
        }

        public Int32 SuccessCount
        {
            get
            {
                return Results.Where(item => item.Succeeded).Count();
            }
            set
            {

            }
        }

        public Int32 FailedCount
        {
            get
            {
                return Results.Where(item => item.Failed).Count();
            }
            set
            {

            }
        }

        public Int32 KnownIssueCount
        {
            get
            {
                return Results.Where(item => item.KnownIssue).Count();
            }
            set
            {

            }
        }
    }
}
