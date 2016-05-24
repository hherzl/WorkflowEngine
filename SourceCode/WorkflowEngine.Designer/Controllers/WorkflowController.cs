using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.Services;
using WorkflowEngine.Designer.ViewModels;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Controllers
{
    public class WorkflowController : ApiController
    {
        protected IWorkflowBusinessObject BusinessObject;

        public WorkflowController(IBusinessObjectService service)
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

        // GET: api/Workflow
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<WorkflowViewModel>() as IComposedModelResponse<WorkflowViewModel>;

            try
            {
                var list = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflows();
                });

                response.Model = list.Select(item => new WorkflowViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Workflow/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflow(new Workflow { ID = id });
                });

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Workflow
        public async Task<HttpResponseMessage> Post([FromBody]WorkflowViewModel value)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.AddWorkflow(value.ToEntity());
                });

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Workflow/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowViewModel value)
        {
            var response = new SingleModelResponse<WorkflowViewModel>() as ISingleModelResponse<WorkflowViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.UpdateWorkflow(id, value.ToEntity());
                });

                response.Model = new WorkflowViewModel(entity);
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
