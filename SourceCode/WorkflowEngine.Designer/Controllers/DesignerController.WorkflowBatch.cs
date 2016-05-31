using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorkflowEngine.Designer.Responses;
using WorkflowEngine.Designer.ViewModels;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Controllers
{
    public partial class DesignerController : ApiController
    {
        // GET: api/Designer/WorkflowBatch
        [Route("WorkflowBatch")]
        public async Task<HttpResponseMessage> GetWorkflowBatches()
        {
            var response = new ComposedModelResponse<WorkflowBatchViewModel>() as IComposedModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowBatches();
                });

                response.Model = model.Select(item => item.ToViewModel()).ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // GET: api/Designer/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> GetWorkflowBatch(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.GetWorkflowBatch(new WorkflowBatch(id));
                });

                response.Model = model.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // POST: api/Designer/WorkflowBatch
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> CreateWorkflowBatch([FromBody]WorkflowBatchViewModel value)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.AddWorkflowBatch(value.ToEntity());
                });

                response.Model = model.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // PUT: api/Designer/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> UpdateWorkflowBatch(Int32 id, [FromBody]WorkflowBatchViewModel value)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.UpdateWorkflowBatch(id, value.ToEntity());
                });

                response.Model = model.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // DELETE: api/Designer/WorkflowBatch/5
        [Route("WorkflowBatch/{id}")]
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.DeleteWorkflowBatch(id, null);
                });

                response.Model = model.ToViewModel();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse(Request);
        }

        // CLONE: api/Designer/WorkflowBatch/5
        [Route("WorkflowBatch/Clone/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Clone(Int32 id)
        {
            var response = new SingleModelResponse<WorkflowBatchViewModel>() as ISingleModelResponse<WorkflowBatchViewModel>;

            try
            {
                var model = await Task.Run(() =>
                {
                    return BusinessObject.CloneWorkflowBatch(id);
                });

                response.Model = model.ToViewModel();
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
