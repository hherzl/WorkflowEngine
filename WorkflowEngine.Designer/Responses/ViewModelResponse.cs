using System;

namespace WorkflowEngine.Designer.Responses
{
    public class ViewModelResponse
    {
        public ViewModelResponse()
        {

        }

        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }
    }
}
