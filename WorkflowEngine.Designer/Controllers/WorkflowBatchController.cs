using System;
using System.Linq;
using System.Net;
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
    public class WorkflowBatchController : ApiController
    {
        protected IWorkflowBusinessObject BusinessObject;

        public WorkflowBatchController(IBusinessObjectService service)
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

        // GET: api/WorkflowBatch
        public async Task<HttpResponseMessage> Get()
        {
            var response = new WorkflowBatchComposedResponse();

            try
            {
                var list = await BusinessObject.GetWorkflowBatches();

                response.Model = list.Select(item => new WorkflowBatchViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await BusinessObject.GetWorkflowBatch(new WorkflowBatch { ID = id });

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
                else
                {
                    response.Model = new WorkflowBatchViewModel(entity);
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/WorkflowBatch
        public async Task<HttpResponseMessage> Post([FromBody]WorkflowBatchViewModel value)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = value.ToEntity();

                await BusinessObject.AddWorkflowBatch(entity);

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowBatchViewModel value)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await BusinessObject.UpdateWorkflowBatch(id, value.ToEntity());

                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/WorkflowBatch/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await BusinessObject.DeleteWorkflowBatch(id, null);

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // CLONE: api/WorkflowBatch/5
        [Route("api/WorkflowBatch/Clone/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Clone(Int32 id)
        {
            var response = new WorkflowBatchSingleResponse();

            try
            {
                var entity = await BusinessObject.CloneWorkflowBatch(id);

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
