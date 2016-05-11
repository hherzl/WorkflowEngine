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

                Console.WriteLine("Validation messages");

                foreach (var item in runner.GetValidationMessages())
                {
                    Console.WriteLine("Workflow batch: {0}", item.WorkflowBatchName);
                    Console.WriteLine("Workflow name: {0}", item.WorkflowName);
                    Console.WriteLine("Workflow task: {0}", item.WorkflowTaskName);
                    Console.WriteLine("Type: {0}", item.MessageType);
                    Console.WriteLine("Message: {0}", item.Message);
                    Console.WriteLine();
                }

                Console.WriteLine("Workflow batch execution started at: '{0}'", DateTime.Now);
                Console.WriteLine();

                runner.StartProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine("Workflow: '{0}'", a.Workflow.Name);
                    Console.WriteLine(" Starting at '{0}'", DateTime.Now);
                };

                runner.ProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine(" Processing...");
                };

                runner.EndProcessWorkflow += (source, a) =>
                {
                    Console.WriteLine(" Ending at '{0}'", DateTime.Now);
                    Console.WriteLine();
                };

                var executionSummary = runner.Execute();

                Console.WriteLine("Workflow batch execution finished at: '{0}'", DateTime.Now);
                Console.WriteLine();

                Console.WriteLine("Execution Summary");
                Console.WriteLine();

                Console.WriteLine("Executed: {0}", executionSummary.ExecutedCount);
                Console.WriteLine("Success: {0}", executionSummary.SuccessCount);
                Console.WriteLine("KnownIssue: {0}", executionSummary.KnownIssueCount);
                Console.WriteLine("Failed: {0}", executionSummary.FailedCount);
                Console.WriteLine("Total: {0}", executionSummary.Results.Count);

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

                var view = new LayoutView
                {
                    DataContext = viewModel
                };

                app.Run(view);
            }
        }
    }
}
