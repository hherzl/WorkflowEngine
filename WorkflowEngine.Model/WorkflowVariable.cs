using System;

namespace WorkflowEngine.Model
{
    public class WorkflowVariable
    {
        public WorkflowVariable()
        {

        }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Value { get; set; }

        public String ReferencedConstant { get; set; }
    }
}
