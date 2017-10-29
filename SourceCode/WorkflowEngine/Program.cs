using System;

namespace WorkflowEngine
{
    public class Program
    {
        [STAThread]
        public static void Main(String[] args)
        {
            Console.WriteLine("Workflow Engine");
            Console.WriteLine();

            var launchArguments = new LaunchArgument();

            foreach (var a in args)
            {
                if (a.StartsWith("/help"))
                {
                    foreach (var help in LaunchArgumentReflector.GetHelp())
                    {
                        Console.WriteLine(help);
                        Console.WriteLine();
                    }

                    break;
                }
                else
                {
                    LaunchArgumentReflector.Reflect(a, launchArguments);
                }
            }

            var launcher = new WorkflowLauncher();

            launcher.Execute(launchArguments);
        }
    }
}
