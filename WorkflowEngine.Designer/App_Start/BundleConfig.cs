using System.Web;
using System.Web.Optimization;

namespace WorkflowEngine.Designer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/vendor/angular/angular.js",
                "~/Scripts/vendor/angular-animate/angular-animate.js",
                "~/Scripts/vendor/angular-aria/angular-aria.js",
                "~/Scripts/vendor/angular-material/angular-material.js",
                "~/Scripts/vendor/angular-route/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                "~/app/services/DesignerService.js",
                "~/app/services/WorkflowBatchService.js",
                "~/app/services/WorkflowService.js",
                "~/app/services/WorkflowTaskService.js",
                "~/app/services/UnitOfWorkService.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                "~/app/controllers/HomeController.js",
                "~/app/controllers/DesignerController.js",
                "~/app/controllers/WorkflowBatchController.js",
                "~/app/controllers/WorkflowController.js",
                "~/app/controllers/WorkflowTaskController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Scripts/vendor/angular-material/angular-material.css"));
        }
    }
}
