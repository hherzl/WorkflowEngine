using System;
using System.Web.Http;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Services;

namespace WorkflowEngine.Designer.Controllers
{
    [RoutePrefix("api/Designer")]
    public partial class DesignerController : ApiController
    {
        protected IWorkflowBusinessObject BusinessObject;

        public DesignerController(IBusinessObjectService service)
        {
            BusinessObject = service.GetBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }

            base.Dispose(disposing);
        }
    }
}
