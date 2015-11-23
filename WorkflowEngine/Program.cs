using System;
using WorkflowEngine.UI;
using WorkflowEngine.UI.ViewModels;
using WorkflowEngine.UI.Views;

namespace WorkflowEngine
{
    public class Program
    {
        [STAThread]
        public static void Main(String[] args)
        {
            foreach (var a in args)
            {
                if (a == "/ui")
                {
                    var app = new App();

                    var viewModel = new LayoutViewModel();

                    var view = new Layout()
                    {
                        DataContext = viewModel
                    };

                    app.Run(view);
                }
                else if (a.StartsWith("/u:"))
                {

                }
                else if (a.StartsWith("/p:"))
                {

                }
            }
        }
    }
}
