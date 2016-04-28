using System;

namespace WorkflowEngine
{
    public class Program
    {
        [STAThread]
        public static void Main(String[] args)
        {
            var launchArguments = new LaunchArgument();

            foreach (var a in args)
            {
                if (a == "/ui")
                {
                    launchArguments.UI = "ui";
                }
                else if (a.StartsWith("/d:"))
                {
                    launchArguments.Domain = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/u:"))
                {
                    launchArguments.User = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/p:"))
                {
                    launchArguments.Password = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/sd:"))
                {
                    launchArguments.SourceDirectory = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/sf:"))
                {
                    launchArguments.SourceFile = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/od:"))
                {
                    launchArguments.OutputDirectory = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/of:"))
                {
                    launchArguments.OutputFile = a.Substring(a.LastIndexOf(":") + 1);
                }
                else if (a.StartsWith("/off:"))
                {
                    launchArguments.OutputFileFormat = a.Substring(a.LastIndexOf(":") + 1);
                }
            }

            var launcher = new WorkflowLauncher();

            launcher.Execute(launchArguments);
        }
    }
}
