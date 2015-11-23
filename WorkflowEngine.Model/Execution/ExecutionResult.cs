using System;
using System.Collections.Generic;

namespace WorkflowEngine.Model.Execution
{
    public class ExecutionResult
    {
        public ExecutionResult()
        {

        }

        public String WorkflowName { get; set; }

        public List<String> ExecutedTasks { get; set; }

        public Boolean Succeeded { get; set; }

        public Boolean Failed { get; set; }

        public Boolean KnownIssue { get; set; }
    }
}
