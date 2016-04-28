using System;
using System.Runtime.Serialization;

namespace WorkflowEngine.Designer.Responses
{
    [DataContract]
    public class ViewModelResponse
    {
        public ViewModelResponse()
        {

        }

        [DataMember(Name = "message")]
        public String Message { get; set; }

        [DataMember(Name = "didError")]
        public Boolean DidError { get; set; }

        [DataMember(Name = "errorMessage")]
        public String ErrorMessage { get; set; }
    }
}
