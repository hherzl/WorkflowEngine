using System;
using System.Text;

namespace WorkflowEngine
{
    public class LaunchArgument
    {
        [LaunchArgumentDescriptor(Argument = "ui", Description = "UI")]
        public String UI { get; set; }

        [LaunchArgumentDescriptor(Argument = "d", Description = "Domain")]
        public String Domain { get; set; }

        [LaunchArgumentDescriptor(Argument = "u", Description = "User")]
        public String User { get; set; }

        [LaunchArgumentDescriptor(Argument = "p", Description = "Password")]
        public String Password { get; set; }

        [LaunchArgumentDescriptor(Argument = "sd", Description = "source directory")]
        public String SourceDirectory { get; set; }

        [LaunchArgumentDescriptor(Argument = "sf", Description = "Source file")]
        public String SourceFile { get; set; }

        [LaunchArgumentDescriptor(Argument = "od", Description = "Output directory")]
        public String OutputDirectory { get; set; }

        [LaunchArgumentDescriptor(Argument = "of", Description = "Output file")]
        public String OutputFile { get; set; }

        [LaunchArgumentDescriptor(Argument = "off", Description = "Output file format")]
        public String OutputFileFormat { get; set; }

        [LaunchArgumentDescriptor(Argument = "help", Description = "Help")]
        public String Help { get; set; }

        public override String ToString()
        {
            var output = new StringBuilder();

            foreach (var property in typeof(LaunchArgument).GetProperties())
            {
                if (property.CanRead)
                {
                    output.AppendFormat("{0}: '{1}'", property.Name, property.GetValue(this, null));
                    output.AppendLine();
                }
            }

            return output.ToString();
        }
    }
}
