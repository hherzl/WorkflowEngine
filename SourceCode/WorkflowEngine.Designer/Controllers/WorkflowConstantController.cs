using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.Services;
using WorkflowEngine.Designer.ViewModels;

namespace WorkflowEngine.Designer.Controllers
{
    public class WorkflowConstantController : ApiController
    {
        protected IWorkflowBusinessObject BusinessObject;

        public WorkflowConstantController(IBusinessObjectService service)
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

        // GET: api/WorkflowConstant
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<WorkflowConstantViewModel>() as IComposedModelResponse<WorkflowConstantViewModel>;

            try
            {
                var list = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowConstants();
                });

                response.Model = list.Select(item => new WorkflowConstantViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }
    }
}
