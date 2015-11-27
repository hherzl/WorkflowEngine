using System;
using WorkflowEngine.UI;
using WorkflowEngine.UI.ViewModels;
using WorkflowEngine.UI.Views;

namespace WorkflowEngine
{
    public class WorkflowLauncher
    {
        public void Execute(LaunchArgument args)
        {
            if (!String.IsNullOrEmpty(args.UI))
            {
                var login = new WorkflowEngine.Model.Security.Login
                {
                    Domain = args.Domain,
                    UserName = args.User,
                    Password = args.Password
                };

                var app = new App();

                var viewModel = new LayoutViewModel();

                var view = new Layout()
                {
                    DataContext = viewModel
                };

                app.Run(view);
            }
        }
    }
}
