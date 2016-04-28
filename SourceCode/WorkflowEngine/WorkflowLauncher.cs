using System;
using WorkflowEngine.Model;
using WorkflowEngine.Model.Execution;
using WorkflowEngine.Model.Security;
using WorkflowEngine.Model.Serialization;
using WorkflowEngine.UI;
using WorkflowEngine.UI.ViewModels;
using WorkflowEngine.UI.Views;

namespace WorkflowEngine
{
    public class WorkflowLauncher
    {
        private ISerializer serializer;

        public WorkflowLauncher()
        {
            serializer = new XmlSerializerImplementation() as ISerializer;
        }

        public void Execute(LaunchArgument args)
        {
            if (!String.IsNullOrEmpty(args.Domain) && !String.IsNullOrEmpty(args.User) && !String.IsNullOrEmpty(args.Password) && !String.IsNullOrEmpty(args.SourceFile))
            {
                var login = new LoginModel(args.Domain, args.User, args.Password);

                var batch = serializer.DeserializeFrom<WorkflowBatch>(args.SourceFile);

                var runner = new WorkflowRunner(batch);

                runner.StartProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine("Workflow: '{0}'", a.Workflow.Name);
                    Console.WriteLine("Starting...");
                };

                runner.ProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine("Processing...");
                };

                runner.EndProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine("Ending...");
                    Console.WriteLine();
                };

                var executionSummary = runner.Execute();

                Console.WriteLine("Execution Summary");
                Console.WriteLine("Executed: '{0}'", executionSummary.ExecutedCount);
                Console.WriteLine("Success: '{0}'", executionSummary.SuccessCount);
                Console.WriteLine("KnownIssue: '{0}'", executionSummary.KnownIssueCount);
                Console.WriteLine("Failed: '{0}'", executionSummary.FailedCount);
                Console.WriteLine();

                if (!String.IsNullOrEmpty(args.OutputFile))
                {
                    serializer.SerializeTo(args.OutputFile, executionSummary);
                }
            }
            else if (!String.IsNullOrEmpty(args.UI))
            {
                var login = new LoginModel(args.Domain, args.User, args.Password);

                var app = new App();

                var viewModel = new LayoutViewModel();

                var view = new LayoutView()
                {
                    DataContext = viewModel
                };

                app.Run(view);
            }
        }
    }
}
