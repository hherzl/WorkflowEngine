using System;

namespace WorkflowEngine
{
    public class LaunchArgumentDescriptor : Attribute
    {
        public String Argument { get; set; }

        public String Description { get; set; }
    }
}
