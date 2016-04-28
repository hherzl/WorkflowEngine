using System;

namespace WorkflowEngine.Model.Execution
{
    public class ProcessWorkflowEventArgs : EventArgs
    {
        public ProcessWorkflowEventArgs(Workflow workflow)
        {
            Workflow = workflow;
        }

        public Workflow Workflow { get; private set; }
    }
}
