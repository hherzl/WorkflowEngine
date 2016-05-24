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
    [RoutePrefix("api/WorkflowBatch")]
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
        [Route("WorkflowBatch")]
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedModelResponse<WorkflowBatchViewModel>() as IComposedModelResponse<WorkflowBatchViewModel>;

            try
            {
                var list = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowBatches();
                });

                response.Model = list.Select(item => new WorkflowBatchViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowBatch(new WorkflowBatch(id));
                });

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/WorkflowBatch
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> Post([FromBody]WorkflowBatchViewModel value)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.AddWorkflowBatch(value.ToEntity());
                });

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]WorkflowBatchViewModel value)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.UpdateWorkflowBatch(id, value.ToEntity());
                });

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // DELETE: api/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.DeleteWorkflowBatch(id, null);
                });

                response.Model = new WorkflowBatchViewModel(entity);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // CLONE: api/WorkflowBatch/5
        [Route("api/WorkflowBatch/Clone/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Clone(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var entity = await Task.Run(() =>
                {
                    return BusinessObject.CloneWorkflowBatch(id);
                });

                response.Model = new WorkflowBatchViewModel(entity);
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
