using System;

namespace WorkflowEngine.Model.Execution
{
    public delegate void StartProcessWorkflow(Object sender, ProcessWorkflowEventArgs args);

    public delegate void ProcessWorkflow(Object sender, ProcessWorkflowEventArgs args);

    public delegate void EndProcessWorkflow(Object sender, ProcessWorkflowEventArgs args);
}
