using System;

namespace WorkflowEngine.Model
{
    public class WorkflowVariable
    {
        public WorkflowVariable()
        {

        }

        public String Token { get; set; }

        public String Value { get; set; }

        public String ReferencedConstant { get; set; }
    }
}
