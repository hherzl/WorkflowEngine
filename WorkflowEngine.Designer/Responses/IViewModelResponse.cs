using System;

namespace WorkflowEngine.Designer.Responses
{
    public interface IViewModelResponse
    {
        String Message { get; set; }

        Boolean DidError { get; set; }

        String ErrorMessage { get; set; }
    }
}
