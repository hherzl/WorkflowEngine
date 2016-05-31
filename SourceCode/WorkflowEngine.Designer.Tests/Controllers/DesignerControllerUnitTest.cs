using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowEngine.Designer.Services;

namespace WorkflowEngine.Designer.Tests.Controllers
{
    [TestClass]
    public partial class DesignerControllerUnitTest
    {
        private IBusinessObjectService service;

        [TestInitialize]
        public void Init()
        {
            service = new BusinessObjectService();
        }

        [TestCleanup]
        public void Dispose()
        {

        }
    }
}
