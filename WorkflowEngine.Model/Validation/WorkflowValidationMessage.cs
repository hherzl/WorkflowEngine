using System;

namespace WorkflowEngine.Model.Validation
{
    public class WorkflowValidationMessage
    {
        public WorkflowValidationMessage()
        {

        }

        public WorkflowValidationMessageType MessageType { get; set; }

        public String WorkflowBatchName { get; set; }

        public String WorkflowName { get; set; }

        public String WorkflowTaskName { get; set; }

        public String Message { get; set; }
    }
}
