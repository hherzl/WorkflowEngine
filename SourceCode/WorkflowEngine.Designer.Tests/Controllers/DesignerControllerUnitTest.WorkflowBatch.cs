using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowEngine.Designer.Controllers;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Tests.Controllers
{
    public partial class DesignerControllerUnitTest
    {
        [TestMethod]
        public async Task DesignerController_GetWorkflowbatches()
        {
            // Arrange
            var controller = new DesignerController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var result = await controller.GetWorkflowBatches();

            // Assert
            var value = default(IComposedModelResponse<WorkflowBatchViewModel>);

            result.TryGetContentValue(out value);

            Assert.IsNotNull(value.Model);
            Assert.IsTrue(value.Model.Count() > 0);
            Console.WriteLine("Model.Count: {0}", value.Model.Count());
        }
    }
}
