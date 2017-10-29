using System;
using System.Collections.Generic;

namespace WorkflowEngine
{
    public class LaunchArgumentReflector
    {
        public static IEnumerable<String> GetHelp()
        {
            var type = typeof(LaunchArgument);

            foreach (var property in type.GetProperties())
            {
                foreach (LaunchArgumentDescriptor attrib in property.GetCustomAttributes(typeof(LaunchArgumentDescriptor), true))
                {
                    yield return String.Format("{0}: {1}", attrib.Argument, attrib.Description);
                }
            }
        }

        public static void Reflect(String argument, LaunchArgument launchArgument)
        {
            var type = launchArgument.GetType();

            foreach (var property in type.GetProperties())
            {
                if (property.CanWrite)
                {
                    foreach (LaunchArgumentDescriptor attrib in property.GetCustomAttributes(typeof(LaunchArgumentDescriptor), true))
                    {
                        if (argument.IndexOf(String.Format("/{0}:", attrib.Argument)) != -1)
                        {
                            property.SetValue(launchArgument, argument.Substring(argument.LastIndexOf(":") + 1));

                            break;
                        }
                    }
                }
            }
        }
    }
}
