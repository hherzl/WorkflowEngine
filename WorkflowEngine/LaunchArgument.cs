using System;
using CommandLine;

namespace WorkflowEngine
{
    public class LaunchArgument
    {
        public LaunchArgument()
        {

        }

        [Option("ui", HelpText = "User Interface")]
        public String UI { get; set; }

        [Option("domain", HelpText = "Domain")]
        public String Domain { get; set; }

        [Option("user", HelpText = "User")]
        public String User { get; set; }

        [Option("password", HelpText = "Password")]
        public String Password { get; set; }

        [Option("sd", HelpText = "Source Directory")]
        public String SourceDirectory { get; set; }

        [Option("sf", HelpText = "Source File")]
        public String SourceFile { get; set; }

        [Option("od", HelpText = "Output Directory")]
        public String OutputDirectory { get; set; }

        [Option("of", HelpText = "Output File")]
        public String OutputFile { get; set; }

        [Option("off", HelpText = "Output File Format")]
        public String OutputFileFormat { get; set; }
    }
}
