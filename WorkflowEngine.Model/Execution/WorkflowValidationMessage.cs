using System;

namespace WorkflowEngine.Model.Execution
{
    public class WorkflowValidationMessage
    {
        public WorkflowValidationMessage()
        {

        }

        public MessageType Type { get; set; }

        public String WorkflowBatchName { get; set; }

        public String WorkflowName { get; set; }

        public String WorkflowTaskName { get; set; }

        public String Message { get; set; }
    }
}
