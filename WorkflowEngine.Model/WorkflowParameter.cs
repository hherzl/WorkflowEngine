using System;

namespace WorkflowEngine.Model
{
    public class WorkflowParameter
    {
        public WorkflowParameter()
        {

        }

        public Int32? ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Value { get; set; }

        public String PresetValue { get; set; }

        public String Variable { get; set; }

        public String Constant { get; set; }
    }
}
