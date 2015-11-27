using System;

namespace WorkflowEngine
{
    public class LaunchArgument
    {
        public LaunchArgument()
        {

        }

        public String UI { get; set; }

        public String Domain { get; set; }

        public String User { get; set; }

        public String Password { get; set; }

        public String SourceDirectory { get; set; }

        public String SourceFile { get; set; }

        public String OutputDirectory { get; set; }

        public String OutputFile { get; set; }

        public String OutputFileFormat { get; set; }
    }
}
