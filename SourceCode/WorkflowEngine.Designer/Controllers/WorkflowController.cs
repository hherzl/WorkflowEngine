using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Models;
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
            var response = new WorkflowComposedResponse();

            try
            {
                var list = await BusinessObject.GetWorkflows();

                response.Model = list.Select(item => new WorkflowViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Workflow/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = await BusinessObject.GetWorkflow(new Workflow { ID = id });

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
                else
                {
                    response.Model = new WorkflowViewModel(entity);
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Workflow
        public async Task <HttpResponseMessage> Post([FromBody]WorkflowViewModel value)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = value.ToEntity();

                await BusinessObject.AddWorkflow(entity);

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Workflow/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowViewModel value)
        {
            var response = new WorkflowSingleResponse();

            try
            {
                var entity = await BusinessObject.UpdateWorkflow(id, value.ToEntity());

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }

                response.Model = new WorkflowViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Workflow/5
        public void Delete(Int32 id)
        {
        }
    }
}
